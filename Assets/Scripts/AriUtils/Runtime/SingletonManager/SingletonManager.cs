/*****************************************************************************
// File Name : SingletonManager.cs
// Author : Arcadia Koederitz
// Creation Date : 10/04/2026
// Last Modified : 10/04/2026
//
// Brief Description : Centralized system for creating easy singletons.
// Inefficient implementation with Auto Searching.  Do NOT use for production code.
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AriUtils
{
    [InitializeOnLoad]
    public static class SingletonManager
    {
        private const bool AUTO_SEARCH_SINGLETONS = true;

        private static Dictionary<Type, MonoBehaviour> _singletonDictionary = new();

        static SingletonManager()
        {
            SceneManager.sceneLoaded += AutoUpdateManagers;
        }

        /// <summary>
        /// Automatically searches through all ISingleton objects in the scene and adds them as singletons, and removes all singletons that don't exist.
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="sceneLoadMode"></param>
        private static void AutoUpdateManagers(Scene scene, LoadSceneMode sceneLoadMode)
        {
            if (AUTO_SEARCH_SINGLETONS)
            {
                // Remove all null singletons.
                List<Type> removedTypes = new();
                foreach(KeyValuePair<Type, MonoBehaviour> pair in _singletonDictionary)
                {
                    if (pair.Value == null)
                    {
                        removedTypes.Add(pair.Key);
                    }
                }
                _singletonDictionary = _singletonDictionary.Where(x => x.Value != null).ToDictionary(kv => kv.Key, KeyValuePair => KeyValuePair.Value);

                // Search through the scene to find all ISingletons and register them automatically.
                MonoBehaviour[] inSceneSingletons = GameObject.FindObjectsByType<MonoBehaviour>();
                foreach(MonoBehaviour behaviour in inSceneSingletons)
                {
                    if (behaviour is ISingleton)
                    {
                        RegisterSingleton(behaviour);
                    }
                }
            }
        }

        /// <summary>
        /// Registers a singleton to the SingletonManager.
        /// </summary>
        /// <param name="singletonScript"></param>
        public static void RegisterSingleton(MonoBehaviour singletonScript)
        {
            Type type = singletonScript.GetType();
            if (!_singletonDictionary.ContainsKey(type))
            {
                _singletonDictionary.Add(type, singletonScript);
                if (singletonScript is ISingleton iSingle)
                {
                    iSingle.SingletonInitialize();
                }
            }
            else if (_singletonDictionary[type] != singletonScript)
            {
                Debug.LogWarning($"Multiple {type} found.  Deleting {singletonScript.name}");
                GameObject.Destroy(singletonScript.gameObject);
            }
        }

        /// <summary>
        /// Unregisters a singleton from the singletonmanager.
        /// </summary>
        /// <param name="singletonScript"></param>
        public static void UnregisterSingleton(MonoBehaviour singletonScript)
        {
            Type type = singletonScript.GetType();
            if (_singletonDictionary.ContainsKey(type))
            {
                _singletonDictionary.Remove(type);
            }
            else
            {
                Debug.LogError($"No Singleton of type {type} to remove.");
            }
        }

        /// <summary>
        /// Gets a singleton of a given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetSingleton<T>() where T: MonoBehaviour
        {
            Type type = typeof(T);
            if (!_singletonDictionary.ContainsKey(type))
            {
                Debug.LogError($"No singleton found for type {type.Name}");
                return null;
            }
            return _singletonDictionary[type] as T;
        }
    }
}
