using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private CameraControlActions _cameraActions;
    private InputAction _pan;
    private Transform _cameraTransform;

    //Horizontal motion
    [SerializeField] 
    private float _maxSpeed = 5f;
    private float _speed;
    [SerializeField]
    private float _acceleration = 10f;
    [SerializeField]
    private float _damping = 15f;

    //Vertical motion - zooming
    [SerializeField]
    private float _stepSize = 2f;
    [SerializeField]
    private float _zoomDampening = 7.5f;
    [SerializeField]
    private float _minHeight = 0.5f;
    [SerializeField]
    private float _maxHeight = 50f;
    [SerializeField]
    private float _zoomSpeed = 2f;

    //Rotation
    [SerializeField]
    private float _maxRotationSpeed = 0.5f;

    //Screen edge motion
    [SerializeField]
    [Range(0f, 0.1f)]
    private float _edgeTolerance = 0.05f;
    [SerializeField]
    private bool _useScreenEdge = false;

    //value set in various functions 
    //used to update the position of the camera base object.
    private Vector3 _targetPosition;

    private float _zoomHeight;

    //used to track and maintain velocity w/o a rigidbody
    private Vector3 _horizontalVelocity;
    private Vector3 _lastPosition;

    //tracks where the dragging action started
    private Vector3 _startDrag;

    private void Awake()
    {
        _cameraActions = new CameraControlActions();
        _cameraTransform = this.GetComponentInChildren<Camera>().transform;
    }

    private void OnEnable()
    {
        _zoomHeight = _cameraTransform.localPosition.y;
        _cameraTransform.LookAt(this.transform);

        _lastPosition = this.transform.position;
        _pan = _cameraActions.Camera.Movement;
        _cameraActions.Camera.Enable();
        _cameraActions.Camera.Rotate.performed += RotateCamera;
        _cameraActions.Camera.Zoom.performed += ZoomCamera;
    }

    private void OnDisable()
    {
        _cameraActions.Camera.Rotate.performed -= RotateCamera;
        _cameraActions.Camera.Zoom.performed -= ZoomCamera;
        _cameraActions.Disable();
    }

    private void Update()
    {
        GetKeyboardMovement();
        DragCamera();

        UpdateVelocity();
        UpdateCameraPosition();
        UpdateBasePosition();
    }

    private void UpdateVelocity()
    {
        _horizontalVelocity = (this.transform.position - _lastPosition) / Time.deltaTime;
        _horizontalVelocity.y = 0;
        _lastPosition = this.transform.position;

    }

    private void GetKeyboardMovement()
    {
        Vector3 inputValue = _pan.ReadValue<Vector2>().x * GetCameraRight() +
            _pan.ReadValue<Vector2>().y * GetCameraForward();
        inputValue = inputValue.normalized;

        if(inputValue.sqrMagnitude > 0.1f)
        {
            _targetPosition += inputValue;
        }
    }

    private Vector3 GetCameraRight()
    {
        Vector3 right = _cameraTransform.right;
        right.y = 0;
        return right;
    }

    private Vector3 GetCameraForward()
    {
        Vector3 forward = _cameraTransform.forward;
        forward.x = 0;
        return forward;
    }

    private void UpdateBasePosition()
    {
        if (_targetPosition.sqrMagnitude > 0.1f)
        {
            _speed = Mathf.Lerp(_speed, _maxSpeed, Time.deltaTime * _acceleration);
            transform.position += _targetPosition * _speed * Time.deltaTime;
        }
        else
        {
            _horizontalVelocity = Vector3.Lerp(_horizontalVelocity, Vector3.zero, Time.deltaTime * _damping);
            transform.position += _horizontalVelocity * Time.deltaTime;
        }

        _targetPosition = Vector3.zero;
    }

    private void RotateCamera(InputAction.CallbackContext inputValue)
    {
        if(!Mouse.current.leftButton.isPressed)
        {
            return;
        }

        float value_x = inputValue.ReadValue<Vector2>().x;
        transform.rotation = Quaternion.Euler(0f, value_x * _maxRotationSpeed + transform.rotation.eulerAngles.y, 0f);
    }

    private void ZoomCamera(InputAction.CallbackContext inputValue)
    {
        float valueStrenght = 0.01f;
        float value = -inputValue.ReadValue<Vector2>().y * valueStrenght;
        if(Math.Abs(value) > 0.1f)
        {
            _zoomHeight = _cameraTransform.localPosition.y + value * _stepSize;
            if(_zoomHeight < _minHeight)
            {
                _zoomHeight = _minHeight;
            }
            else if(_zoomHeight > _maxHeight)
            {
                _zoomHeight = _maxHeight;
            }
        }
    }

    private void UpdateCameraPosition()
    {
        Vector3 zoomTarget = new Vector3(_cameraTransform.localPosition.x, 
            _zoomHeight, 
            _cameraTransform.localPosition.z);
        zoomTarget -= _zoomSpeed * (_zoomHeight - _cameraTransform.localPosition.y) * Vector3.forward;
        _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, zoomTarget, Time.deltaTime * _zoomDampening);
        _cameraTransform.LookAt(this.transform);
    }

    private void CheckMouseAtScreenEdge()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 moveDirection = Vector3.zero;

        if(mousePosition.x < _edgeTolerance * Screen.width)
        {
            moveDirection += -GetCameraRight();
        }
        else if (mousePosition.x > (1 - _edgeTolerance) * Screen.width)
        {
            moveDirection += GetCameraRight();
        }

        if (mousePosition.y < _edgeTolerance * Screen.height)
        {
            moveDirection += -GetCameraForward();
        }
        else if (mousePosition.y > (1 - _edgeTolerance) * Screen.height)
        {
            moveDirection += GetCameraForward();
        }

        _targetPosition += moveDirection;
    }

    private void DragCamera() //???
    {
        if (!Mouse.current.middleButton.isPressed)
        {
            return;
        }

        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if(plane.Raycast(ray, out float distance))
        {
            if(Mouse.current.middleButton.wasPressedThisFrame)
            {
                _startDrag = ray.GetPoint(distance);
            }
            else
            {
                _targetPosition += _startDrag - ray.GetPoint(distance);
            }
        }
    }
}
