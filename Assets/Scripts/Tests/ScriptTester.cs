using AriUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class ScriptTester : MonoBehaviour
{
    [SerializeField] private SerializedInterface<ITestInterface> testReference;
    [SerializeReference, ClassDropdown] private TestInterfaceClass testDropdown;
    [SerializeField, ComponentReference] private Rigidbody2D body;
    [SerializeField] private SceneField scene;

    [ContextMenu("RealoadScene")]
    public void ReloadScene()
    {
        SceneManager.LoadScene(scene);
    }

    private void Start()
    {
        testReference.Interface.TestFunction();
    }
}
