/*****************************************************************************
// File Name :  SliderSetting.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Controls a setting through a slider.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace AriUtils.UISettings
{
    public abstract class SliderSetting : SettingControl<float>
    {
        [SerializeField] private Slider slider;

        private void Awake()
        {
            Initialize();

            float value = PlayerPrefs.GetFloat(PlayerPrefsKey, DefaultValue);
            SetSettingValue(value);
            slider.SetValueWithoutNotify(value);
        }

        public sealed override void SetSettingValue(float value)
        {
            OnValueChanged(value);
            PlayerPrefs.SetFloat(PlayerPrefsKey, value);
        }
    }
}
