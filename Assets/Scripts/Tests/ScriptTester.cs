using AriUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class ScriptTester : MonoBehaviour
{
    [SerializeField] private SerializedInterface<ITestInterface> testReference;
    [SerializeReference, ClassDropdown] private ITestInterface testDropdown;
    [SerializeField, ComponentReference] private Rigidbody2D body;
    [SerializeField] private SceneField scene;
    [Header("Timelines")]
    [SerializeField] private AsyncTimeline asyncTimeline;
    [SerializeField] private CoroutineTimeline coroutineTimeline;

    [ContextMenu("RealoadScene")]
    public void ReloadScene()
    {
        SceneManager.LoadScene(scene);
    }

    private void Start()
    {
        testReference.Interface.TestFunction();
        testReference.Interface = new TestInterfaceClass();
        testReference.Interface.TestFunction();
    }
}
