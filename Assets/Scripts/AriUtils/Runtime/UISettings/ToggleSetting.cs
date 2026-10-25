/*****************************************************************************
// File Name : ToggleSetting.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Controls a boolean setting with a toggle.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace AriUtils.UISettings
{
    public abstract class ToggleSetting : SettingControl<bool>
    {
        [SerializeField] private Toggle toggle;

        private void Awake()
        {
            Initialize();

            bool value = GetPlayerPrefsBool(PlayerPrefsKey, DefaultValue);
            SetSettingValue(value);
            toggle.SetIsOnWithoutNotify(value);
        }

        public override sealed void SetSettingValue(bool value)
        {
            OnValueChanged(value);
            SetPlayerPrefsBool(PlayerPrefsKey, value);
        }

        protected static void SetPlayerPrefsBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        protected static bool GetPlayerPrefsBool(string key, bool defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) > 0;
        }
    }
}
