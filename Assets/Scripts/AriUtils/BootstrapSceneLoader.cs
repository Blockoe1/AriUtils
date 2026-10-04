/*****************************************************************************
// File Name : BootstrapSceneLoader.cs
// Author : Arcadia Koederitz
// Creation Date : 10/04/2026
// Last Modified : 10/04/2026
//
// Brief Description : Automatically loads a scene called "BootstrapScene" when the project starts.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AriUtils
{
    public static class BootstrapSceneLoader
    {
        private const string BOOTSTRAP_SCENE_NAME = "BootstrapScene";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadBootstrapScene()
        {
            if (SceneManager.GetSceneByName(BOOTSTRAP_SCENE_NAME).IsValid())
            {
                SceneManager.LoadScene(BOOTSTRAP_SCENE_NAME, LoadSceneMode.Additive);
            }
        }
    }
}
