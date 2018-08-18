using System;
using System.Collections.Generic;
using KeyboardMacroCreator.KeyboardData.Keys.InputProvider;

namespace KeyboardMacroCreator.KeyboardData.Keys
{
    public class KeyboardEvents
    {
        private readonly Dictionary<KeyboardInputProviderType, IKeyboardInputProvider> _inputProviders =
            new Dictionary<KeyboardInputProviderType, IKeyboardInputProvider>();

        private readonly List<System.Windows.Forms.Keys> _pressedKeys = new List<System.Windows.Forms.Keys>();

        private IKeyboardInputProvider _keyboardKeyEventProvider;
        public KeyCombination LastKeyCombination = new KeyCombination();

        public KeyboardEvents()
        {
            _inputProviders.Add(KeyboardInputProviderType.WindowHook, new WindowHookInputProvider());
        }

        public bool Listen { get; set; }

        public KeyboardInputProviderType KeyboardKeyEventProviderType
        {
            get => _keyboardKeyEventProvider.Type;
            set
            {
                if (_keyboardKeyEventProvider != null)
                    _keyboardKeyEventProvider.OnKeyEvent -= OnKeyboardKeyEventProviderEvent;
                _keyboardKeyEventProvider = _inputProviders[value];
                _keyboardKeyEventProvider.OnKeyEvent += OnKeyboardKeyEventProviderEvent;
            }
        }

        public event Action<KeyboardKey> OnKeyPressed;
        public event Action<KeyCombination> OnKeyCombinationPressed;

        public void SetInputProvider(KeyboardInputProviderType type)
        {
            KeyboardKeyEventProviderType = type;
        }

        private void OnKeyboardKeyEventProviderEvent(KeyboardKey key)
        {
            if (Listen)
            {
                if (key.IsInjected)
                    return;
                switch (key.State)
                {
                    case KeyboardKeyState.Up:
                        if (!_pressedKeys.Contains(key.Value)) return;
                        _pressedKeys.Remove(key.Value);
                        OnKeyPressed?.Invoke(key);
                        break;
                    case KeyboardKeyState.Down:
                        if (_pressedKeys.Contains(key.Value)) return;
                        _pressedKeys.Add(key.Value);
                        LastKeyCombination.AddKey(key);
                        OnKeyPressed?.Invoke(key);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (_pressedKeys.Count == 0)
                    if (LastKeyCombination.Count > 1)
                    {
                        OnKeyCombinationPressed?.Invoke(LastKeyCombination);
                        LastKeyCombination = new KeyCombination();
                    }
            }
        }
    }
}