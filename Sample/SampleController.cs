using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TsfUnity.Example
{
    public class SampleController : MonoBehaviour
    {
        [SerializeField]
        TinySoundFont tinySoundFont;

        public int preset = 0;

        void Update()
        {
            foreach (var item in keyMap)
            {
                if (Input.GetKeyDown(item.Key))
                {
                    tinySoundFont.soundfont.NoteOn(preset, item.Value, 1.0f);
                    Debug.Log("Down");
                }

                if (Input.GetKeyUp(item.Key))
                {
                    tinySoundFont.soundfont.NoteOff(preset, item.Value);
                    Debug.Log("Up");
                }
            }
        }

        static Dictionary<KeyCode, int> keyMap = new Dictionary<KeyCode, int>()
        {
            { KeyCode.C, 60 },
            { KeyCode.D, 62 },
            { KeyCode.E, 64 },
            { KeyCode.F, 65 },
            { KeyCode.G, 67 },
            { KeyCode.A, 69 },
            { KeyCode.B, 71 },
        };
    }

}

