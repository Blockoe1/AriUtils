using CustomAttributes;
using UnityEngine;

public class InterfaceSerializationTester : MonoBehaviour
{
    [SerializeReference, ClassDropdown(typeof(ITestInterface))] private ITestInterface testReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
