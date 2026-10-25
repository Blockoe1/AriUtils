/*****************************************************************************
// File Name : FullscreenSetting.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Automatically controls the fullscreen status of the game.
*****************************************************************************/
using AriUtils.UISettings;
using UnityEngine;

namespace AriUtils.Addons.UISettings
{
    public class FullscreenSetting : ToggleSetting
    {
        protected override string PlayerPrefsKey => "Fullsceen";

        protected override bool DefaultValue => true;

        protected override void OnValueChanged(bool value)
        {
            Screen.fullScreen = value;
        }
    }
}
