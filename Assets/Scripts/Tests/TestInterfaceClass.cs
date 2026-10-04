using UnityEngine;

[System.Serializable]
public class TestInterfaceClass : ITestInterface
{
    [SerializeField] private float param;

    public void TestFunction()
    {
        Debug.Log("Worked for TestClass");
    }
}
