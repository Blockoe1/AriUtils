using UnityEngine;

namespace AriUtils
{
    public class TestMonoBehaviour : MonoBehaviour, ITestInterface
    {
        public void TestFunction()
        {
            Debug.Log("Worked for MonoBehaviour.");
        }
    }
}
