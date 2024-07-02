using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;


    private InputActionsMap _inputActions;

    private void Awake()
    {
        _inputActions = new InputActionsMap();
        _inputActions.Camera.Enable();
    }

    private void Update()
    {
        TestOrbit();
    }


    public void TestOrbit()
    {
        if(_inputActions.Camera.Orbit.IsPressed())
        {
            Debug.Log("YES");
        }
    }
    
}
