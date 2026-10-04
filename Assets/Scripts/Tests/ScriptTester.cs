using AriUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class ScriptTester : MonoBehaviour
{
    [SerializeReference, ClassDropdown(typeof(ITestInterface))] private ITestInterface testReference;
    [SerializeField, ComponentReference] private Rigidbody2D body;
    [SerializeField] private SceneField scene;

    [ContextMenu("RealoadScene")]
    public void ReloadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
