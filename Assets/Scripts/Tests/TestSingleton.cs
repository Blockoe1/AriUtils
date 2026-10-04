using UnityEngine;

namespace AriUtils
{
    public class TestSingleton : MonoBehaviour, ISingleton
    {
        public void SingletonInitialize()
        {
            Debug.Log("Singleton Initialized!");
        }
    }
}
