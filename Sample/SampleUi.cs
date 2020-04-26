using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TsfUnity.Example
{
    public class SampleUi : MonoBehaviour
    {
        [SerializeField] TinySoundFont soundfont;
        [SerializeField] SampleController controller;

        [SerializeField] Dropdown presetSelector;
        [SerializeField] Text path;

        void Awake()
        {
            soundfont.soundfont.onLoaded += OnSoundFontLoaded;
        }

        private void OnSoundFontLoaded()
        {
            List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

            foreach (var preset in soundfont.soundfont.presets)
                options.Add(new Dropdown.OptionData(preset));

            presetSelector.options = options;
            path.text = soundfont.path;
        }

        public void OnPresetChanged()
        {
            controller.preset = presetSelector.value;
        }
    }
}
