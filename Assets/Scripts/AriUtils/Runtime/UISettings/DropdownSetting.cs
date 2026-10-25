/*****************************************************************************
// File Name : DropdownSetting.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Controls a discrete integer/enum setting with a dropdown.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace AriUtils.UISettings
{
    public abstract class DropdownSetting : SettingControl<int>
    {
        [SerializeField] private Dropdown dropdown;

        private void Awake()
        {
            Initialize();
        }

        public sealed override void SetSettingValue(int value)
        {
            OnValueChanged(value);
            PlayerPrefs.SetInt(PlayerPrefsKey, value);
        }
    }
}
