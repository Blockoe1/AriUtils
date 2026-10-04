using AriUtils;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScriptTester : MonoBehaviour
{
    [SerializeReference, ClassDropdown(typeof(ITestInterface))] private ITestInterface testReference;
    [SerializeField, ComponentReference] private Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
