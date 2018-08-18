using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace KeyboardMacroCreator.MacroData.Recorder
{
    public class KeyboardMacroRecording : List<MacroKey>, IDisposable
    {
        public KeyboardMacroRecording()
        {
        }

        public KeyboardMacroRecording(MacroKey[] keys)
        {
            AddRange(keys);
        }

        [JsonIgnore]
        public bool IsDisposed { get; set; }

        public void Dispose()
        {
            Clear();
            IsDisposed = true;
            OnDisposed?.Invoke();
        }

        public event Action OnDisposed;

        public void AddKey(MacroKey key)
        {
            Add(key);
        }

        public override string ToString()
        {
            var textDisplay = new StringBuilder();
            foreach (var key in this)
                textDisplay.Append($"{key} ");
            return textDisplay.ToString();
        }
    }
}