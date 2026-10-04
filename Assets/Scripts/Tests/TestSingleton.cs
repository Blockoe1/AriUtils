using UnityEngine;

namespace AriUtils
{
    public class TestSingleton : MonoBehaviour
    {
        private static TestSingleton instance;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
