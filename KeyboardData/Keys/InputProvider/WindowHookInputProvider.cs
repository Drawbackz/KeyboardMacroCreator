using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KeyboardMacroCreator.KeyboardData.Keys.InputProvider
{
    public class WindowHookInputProvider : IKeyboardInputProvider, IDisposable
    {
        public enum KeyboardState
        {
            KeyDown = 0x0100,
            KeyUp = 0x0101,
            SysKeyDown = 0x0104,
            SysKeyUp = 0x0105
        }

        private HookProc _hookProc;
        private IntPtr _user32LibraryHandle;

        private IntPtr _windowsHookHandle;


        public WindowHookInputProvider()
        {
            _windowsHookHandle = IntPtr.Zero;
            _user32LibraryHandle = IntPtr.Zero;
            _hookProc =
                LowLevelKeyboardProc; // we must keep alive _hookProc, because GC is not aware about SetWindowsHookEx behaviour.

            _user32LibraryHandle = LoadLibrary("User32");
            if (_user32LibraryHandle == IntPtr.Zero)
            {
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode,
                    $"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }


            var WH_KEYBOARD_LL = 13;
            _windowsHookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, _hookProc, _user32LibraryHandle, 0);
            if (_windowsHookHandle == IntPtr.Zero)
            {
                var errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode,
                    $"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
        }

        public bool Listen { get; set; }
        public KeyboardInputProviderType Type => KeyboardInputProviderType.WindowHook;

        public event Action<KeyboardKey> OnKeyEvent;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_windowsHookHandle != IntPtr.Zero)
                {
                    if (!UnhookWindowsHookEx(_windowsHookHandle))
                    {
                        var errorCode = Marshal.GetLastWin32Error();
                        throw new Win32Exception(errorCode,
                            $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                    }
                    _windowsHookHandle = IntPtr.Zero;

                    // ReSharper disable once DelegateSubtraction
                    _hookProc -= LowLevelKeyboardProc;
                }

            if (_user32LibraryHandle != IntPtr.Zero)
            {
                if (!FreeLibrary(_user32LibraryHandle)) // reduces reference to library by 1.
                {
                    var errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode,
                        $"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                _user32LibraryHandle = IntPtr.Zero;
            }
        }

        ~WindowHookInputProvider()
        {
            Dispose(false);
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool FreeLibrary(IntPtr hModule);

        /// <summary>
        ///     The SetWindowsHookEx function installs an application-defined hook procedure into a hook chain.
        ///     You would install a hook procedure to monitor the system for certain types of events. These events are
        ///     associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">hook type</param>
        /// <param name="lpfn">hook procedure</param>
        /// <param name="hMod">handle to application instance</param>
        /// <param name="dwThreadId">thread identifier</param>
        /// <returns>If the function succeeds, the return value is the handle to the hook procedure.</returns>
        [DllImport("USER32", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

        /// <summary>
        ///     The UnhookWindowsHookEx function removes a hook procedure installed in a hook chain by the SetWindowsHookEx
        ///     function.
        /// </summary>
        /// <param name="hhk">handle to hook procedure</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("USER32", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);

        /// <summary>
        ///     The CallNextHookEx function passes the hook information to the next hook procedure in the current hook chain.
        ///     A hook procedure can call this function either before or after processing the hook information.
        /// </summary>
        /// <param name="hHook">handle to current hook</param>
        /// <param name="code">hook code passed to hook procedure</param>
        /// <param name="wParam">value passed to hook procedure</param>
        /// <param name="lParam">value passed to hook procedure</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("USER32", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

        public IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var fEatKeyStroke = false;

            var wparamTyped = wParam.ToInt32();
            if (Enum.IsDefined(typeof(KeyboardState), wparamTyped))
            {
                var o = Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent));
                var p = (LowLevelKeyboardInputEvent) o;
                var keyState = (KeyboardState) wparamTyped;
                var keyUp = keyState == KeyboardState.KeyUp || keyState == KeyboardState.SysKeyUp;
                var keyDown = keyState == KeyboardState.KeyDown || keyState == KeyboardState.SysKeyDown;
                var key = (System.Windows.Forms.Keys) p.VirtualCode;
                var state = keyUp ? KeyboardKeyState.Up : keyDown ? KeyboardKeyState.Down : KeyboardKeyState.Unknown;
                Console.WriteLine("---");
                var flags = new LowLevelKeyboardInputEventFlags(p.Flags);
                OnKeyEvent?.Invoke(new KeyboardKey {IsInjected = flags.IsInjected, Value = key, State = state});
            }

            return fEatKeyStroke ? (IntPtr) 1 : CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct LowLevelKeyboardInputEvent
        {
            /// <summary>
            ///     A virtual-key code. The code must be a value in the range 1 to 254.
            /// </summary>
            public int VirtualCode;

            /// <summary>
            ///     A hardware scan code for the key.
            /// </summary>
            public int HardwareScanCode;

            /// <summary>
            ///     The extended-key flag, event-injected Flags, context code, and transition-state flag. This member is specified as
            ///     follows. An application can use the following values to test the keystroke Flags. Testing LLKHF_INJECTED (bit 4)
            ///     will tell you whether the event was injected. If it was, then testing LLKHF_LOWER_IL_INJECTED (bit 1) will tell you
            ///     whether or not the event was injected from a process running at lower integrity level.
            /// </summary>
            public int Flags;

            /// <summary>
            ///     The time stamp stamp for this message, equivalent to what GetMessageTime would return for this message.
            /// </summary>
            public int TimeStamp;

            /// <summary>
            ///     Additional information associated with the message.
            /// </summary>
            public IntPtr AdditionalInformation;
        }

        public class LowLevelKeyboardInputEventFlags
        {
            private bool _reserved1;
            private bool _reserved2;

            private bool _reserved3;
            public bool AltDown;
            public bool IsExtended;

            public bool IsInjected;

            public bool IsLowLevel;

            public bool TransitionState;

            public LowLevelKeyboardInputEventFlags(int eventFlags)
            {
                var bits = new BitArray(BitConverter.GetBytes(eventFlags));
                IsExtended = bits[0];
                IsLowLevel = bits[1];
                _reserved1 = bits[2];
                _reserved2 = bits[3];
                IsInjected = bits[4];
                AltDown = bits[5];
                _reserved3 = bits[6];
                TransitionState = bits[7];
            }
        }
    }
}