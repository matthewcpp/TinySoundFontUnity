using System.IO;
using UnityEngine;

namespace TsfUnity
{
    public class TinySoundFont : MonoBehaviour
    {
        public enum FontLocation
        {
            File, Resources
        }

        public string path;

        [SerializeField]
        FontLocation fontLocation = FontLocation.Resources;

        [SerializeField]
        bool loadOnStart = true;

        public Soundfont soundfont { get; } = new Soundfont();

        private void Start()
        {
            if (loadOnStart)
            {
                if (fontLocation == FontLocation.Resources)
                    LoadResource(path);
                else
                    LoadFile(path);
            }
        }

        public void LoadFile(string filepath)
        {
            soundfont.LoadFromFile(path);
        }

        public void LoadResource(string path)
        {
            var asset = Resources.Load<TextAsset>(path);
            soundfont.LoadFromMemory(asset.bytes);
        }

        private void OnDestroy()
        {
            Debug.Log("TinySoundFontDestroy");
            soundfont.Close();
        }
    }

}
