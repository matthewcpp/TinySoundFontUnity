using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace TsfUnity
{
    public class Soundfont
    {
        public delegate void OnLoaded();
        public OnLoaded onLoaded;

        IntPtr tsf = IntPtr.Zero;

        public string[] presets { get; private set; }

        public void LoadFromFile(string filename)
        {
            tsf = Plugin.tsf_unity_load_from_file(filename);
            Init();
        }

        public void LoadFromMemory(byte[] data)
        {
            tsf = Plugin.tsf_unity_load_from_memory(data, data.Length);
            Init();
        }

        private void Init()
        {
            if (tsf == IntPtr.Zero)
                throw new TsfException("Unable to load file");

            presets = new string[Plugin.tsf_unity_get_preset_count(tsf)];

            for (int i = 0; i < presets.Length; i++)
                presets[i] = Marshal.PtrToStringAnsi(Plugin.tsf_unity_get_preset_name(tsf, i));

            onLoaded?.Invoke();
        }

        public void NoteOn(int presetIndex, int key, float velocity)
        {
            Plugin.tsf_unity_note_on(tsf, presetIndex, key, velocity);
        }

        public void NoteOff(int presetIndex, int key)
        {
            Plugin.tsf_unity_note_off(tsf, presetIndex, key);
        }

        public void AllNotesOff()
        {
            Plugin.tsf_unity_all_notes_off(tsf);
        }

        public void Close()
        {
            if (tsf != IntPtr.Zero)
            {
                Plugin.tsf_unity_close(tsf);
                tsf = IntPtr.Zero;
            }
        }
    }
}

