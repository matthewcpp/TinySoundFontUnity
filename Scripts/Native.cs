using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace TsfUnity
{
    public static class Plugin
    {
        public static IntPtr tsf_unity_load_from_file(string filename)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                return IOS.tsf_unity_load_from_file(filename);
            else
                return Dll.tsf_unity_load_from_file(filename);
        }

        public static IntPtr tsf_unity_load_from_memory(byte[] data, int size)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                return IOS.tsf_unity_load_from_memory(data, size);
            else
                return Dll.tsf_unity_load_from_memory(data, size);
        }

        public static void tsf_unity_close(IntPtr context)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                IOS.tsf_unity_close(context);
            else
                Dll.tsf_unity_close(context);
        }

        public static int tsf_unity_get_preset_count(IntPtr context)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                return IOS.tsf_unity_get_preset_count(context);
            else
                return Dll.tsf_unity_get_preset_count(context);
        }

        public static IntPtr tsf_unity_get_preset_name(IntPtr context, int preset)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                return IOS.tsf_unity_get_preset_name(context, preset);
            else
                return Dll.tsf_unity_get_preset_name(context, preset);
        }

        public static void tsf_unity_note_off(IntPtr context, int preset_index, int key)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                IOS.tsf_unity_note_off(context, preset_index, key);
            else
                Dll.tsf_unity_note_off(context, preset_index, key);
        }

        public static void tsf_unity_note_on(IntPtr context, int preset_index, int key, float vel)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                IOS.tsf_unity_note_on(context, preset_index, key, vel);
            else
                Dll.tsf_unity_note_on(context, preset_index, key, vel);
        }

        public static void tsf_unity_all_notes_off(IntPtr context)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
                IOS.tsf_unity_all_notes_off(context);
            else
                Dll.tsf_unity_all_notes_off(context);
        }
    }
    
    public static class IOS
    {
        [DllImport("__Internal")]
        public static extern IntPtr tsf_unity_load_from_file(string filename);

        [DllImport("__Internal")]
        public static extern IntPtr tsf_unity_load_from_memory(byte[] data, int size);

        [DllImport("__Internal")]
        public static extern void tsf_unity_close(IntPtr context);

        [DllImport("__Internal")]
        public static extern int tsf_unity_get_preset_count(IntPtr context);

        [DllImport("__Internal")]
        public static extern IntPtr tsf_unity_get_preset_name(IntPtr context, int preset);

        [DllImport("__Internal")]
        public static extern void tsf_unity_note_off(IntPtr context, int preset_index, int key);

        [DllImport("__Internal")]
        public static extern void tsf_unity_note_on(IntPtr context, int preset_index, int key, float vel);

        [DllImport("__Internal")]
        public static extern void tsf_unity_all_notes_off(IntPtr context);
    }
    
    public static class Dll
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
