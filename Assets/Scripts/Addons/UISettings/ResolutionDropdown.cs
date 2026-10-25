/*****************************************************************************
// File Name : ResolutionSetting.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Automatically controls the resolution of the game via an integrated script.
*****************************************************************************/
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AriUtils.Addons.UISettings
{
    public class ResolutionDropdown : TMP_DropdownSetting
    {
        private static Resolution[] _resolutions;
        private static Resolution[] Resolutions
        {
            get
            {
                if (_resolutions == null)
                {
                    _resolutions = Screen.resolutions;

                    // Filter out duplicates
                    List<Resolution> resList = new();
                    foreach(Resolution res in _resolutions)
                    {
                        // Compre res to all the resolutions already in the res list.  If none match, then add it.
                        if (!resList.Any(x => CompareResolutions(x, res)))
                        {
                            resList.Add(res);
                        }
                    }
                    _resolutions = resList.ToArray();
                }
                return _resolutions;
            }
        }

        protected override int OptionLength => Resolutions.Length;

        protected override string PlayerPrefsKey => "Resolution";

        protected override int DefaultValue => 0;

        /// <summary>
        /// Create the list of possible resolution strings to display.
        /// </summary>
        /// <param name="startingValue"></param>
        /// <returns></returns>
        protected override List<string> InitializeOptions(ref int startingValue)
        {
            List<string> resolutionOptions = new();
            for(int i = 0; i < Resolutions.Length; i++)
            {
                resolutionOptions.Add(Resolutions[i].width + " x " + Resolutions[i].height);

                if (CompareResolutions(Resolutions[i], Screen.currentResolution))
                {
                    startingValue = i;
                }
            }
            return resolutionOptions;
        }

        protected override void OnValueChanged(int value)
        {
            Resolution res = Resolutions[value];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        }

        private static bool CompareResolutions(Resolution r1, Resolution r2)
        {
            return r1.width == r2.width && r1.height == r2.height;
        }
    }
}
