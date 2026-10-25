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
using System.Collections.Generic;

namespace AriUtils.UISettings
{
    public abstract class DropdownSetting : SettingControl<int>
    {
        [SerializeField] private Dropdown dropdown;

        protected abstract int OptionLength { get; }

        private void Awake()
        {
            Initialize();

            // Setup the dropdown.
            int currentValue = -1;
            if (PlayerPrefs.HasKey(PlayerPrefsKey))
            {
                currentValue = PlayerPrefs.GetInt(PlayerPrefsKey);
            }
            if (currentValue >= OptionLength)
            {
                currentValue = -1;
            }

            dropdown.ClearOptions();
            List<string> options = InitializeOptions(ref currentValue);
            dropdown.AddOptions(options);

            SetSettingValue(currentValue);
            dropdown.SetValueWithoutNotify(currentValue);
            dropdown.RefreshShownValue();
        }

        protected abstract List<string> InitializeOptions(ref int startingValue);
     

        public sealed override void SetSettingValue(int value)
        {
            OnValueChanged(value);
            PlayerPrefs.SetInt(PlayerPrefsKey, value);
        }
    }
}
