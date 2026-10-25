/*****************************************************************************
// File Name : TMP_DropdownSetting.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Controls a discrete integer/enum setting with a dropdown integrated with TMP.
*****************************************************************************/
using AriUtils.UISettings;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AriUtils.Addons.UISettings
{
    public abstract class TMP_DropdownSetting : SettingControl<int>
    {
        [SerializeField] private TMP_Dropdown dropdown;

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
