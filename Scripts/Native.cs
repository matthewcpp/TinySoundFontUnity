using System;
using System.Runtime.InteropServices;

namespace TsfUnity
{
    public class Native
    {
        [DllImport("tsf_unity")]
        public static extern IntPtr tsf_unity_load_from_file(string filename);

        [DllImport("tsf_unity")]
        public static extern IntPtr tsf_unity_load_from_memory(byte[] data, int size);

        [DllImport("tsf_unity")]
        public static extern void tsf_unity_close(IntPtr context);

        [DllImport("tsf_unity")]
        public static extern int tsf_unity_get_preset_count(IntPtr context);

        [DllImport("tsf_unity")]
        public static extern IntPtr tsf_unity_get_preset_name(IntPtr context, int preset);

        [DllImport("tsf_unity")]
        public static extern void tsf_unity_note_off(IntPtr context, int preset_index, int key);

        [DllImport("tsf_unity")]
        public static extern void tsf_unity_note_on(IntPtr context, int preset_index, int key, float vel);

        [DllImport("tsf_unity")]
        public static extern void tsf_unity_all_notes_off(IntPtr context);
    }
}
