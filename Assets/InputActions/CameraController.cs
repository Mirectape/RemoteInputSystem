using FMSolution.FMNetwork;
using System;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private CameraControlActions _cameraActions;
    private InputAction _movement;
    private Transform _cameraTransform;

    [SerializeField]
    private FMNetworkManager _fmManager;

    //Horizontal motion
    [SerializeField] 
    private float _maxSpeed = 5f;
    private float _speed;
    [SerializeField]
    private float _acceleration = 10f;
    [SerializeField]
    private float _damping = 5f;

    //Vertical motion - zooming
    [SerializeField]
    private float _stepSize = 0.3f;
    [SerializeField]
    private float _zoomDampening = 7.5f;
    [SerializeField]
    private float _minDistance = 0.5f;
    [SerializeField]
    private float _maxDistance = 50f;

    //Rotation
    [SerializeField]
    private float _maxRotationSpeed = 0.5f;

    //value set in various functions 
    //used to update the position of the camera base object.
    private Vector3 _targetPosition;

    private float _zoomDistance;

    //used to track and maintain velocity w/o a rigidbody
    private Vector3 _verticalVelocity;
    private Vector3 _lastPosition;

    //tracks where the dragging action started
    private Vector3 _startDrag;
    private Vector3 _planeNormal; 

    private void Awake()
    {
        _cameraActions = new CameraControlActions();
        _cameraTransform = this.GetComponentInChildren<Camera>().transform;
        _planeNormal = Vector3.forward;
    }

    private void OnEnable()
    {
        _zoomDistance = _cameraTransform.localPosition.z;
        _cameraTransform.LookAt(this.transform);

        _lastPosition = this.transform.position;
        _movement = _cameraActions.Camera.Movement;
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
        GetKeyboardPanMovement();
        DragCamera();

        UpdateVelocity();
        UpdateCameraPosition();
        UpdateBasePosition();
    }

    private void UpdateVelocity()
    {
        _verticalVelocity = (this.transform.position - _lastPosition) / Time.deltaTime;
        _lastPosition = this.transform.position;
    }

    private void GetKeyboardPanMovement()
    {
        Vector3 inputValue = _movement.ReadValue<Vector2>().x * GetCameraRight() +
            _movement.ReadValue<Vector2>().y * GetCameraUp();
        inputValue = inputValue.normalized;

        if (inputValue.sqrMagnitude > 0.1f)
        {
            _targetPosition += inputValue;
        }
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
            _verticalVelocity = Vector3.Lerp(_verticalVelocity, Vector3.zero, Time.deltaTime * _damping);
            transform.position += _verticalVelocity * Time.deltaTime;
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
        _planeNormal = transform.rotation * Vector3.forward;
        RotateCameraSendToClient(value_x);
    }

    private void RotateCameraSendToClient(float value_x)
    {
        var valueString = string.Format(CultureInfo.InvariantCulture, "r_{0}", value_x);
        
        
        _fmManager.SendToOthers(valueString);
    }

    private void ZoomCamera(InputAction.CallbackContext inputValue)
    {
        float valueStrength = 0.01f;
        float value = -inputValue.ReadValue<Vector2>().y * valueStrength;
        if(Math.Abs(value) > 0.1f)
        {
            _zoomDistance += value * _stepSize;
            Debug.Log(_cameraTransform.localPosition.z);
            if(_zoomDistance < _minDistance)
            {
                _zoomDistance = _minDistance;
            }
            else if(_zoomDistance > _maxDistance)
            {
                _zoomDistance = _maxDistance;
            }
        }
        ZoomCameraSendToClient(value);
    }

    private void ZoomCameraSendToClient(float value)
    {
        var valueString = string.Format(CultureInfo.InvariantCulture, "z_{0}", value);
        _fmManager.SendToOthers(valueString);
    }

    private void UpdateCameraPosition()
    {
        Vector3 zoomTarget = new Vector3(_cameraTransform.localPosition.x,
                                        _cameraTransform.localPosition.y,
                                        _zoomDistance);
        _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, zoomTarget, Time.deltaTime * _zoomDampening);
        _cameraTransform.LookAt(this.transform);
    }

    /// <summary>
    /// Use this func to pan around
    /// </summary>
    private void DragCamera()
    {
        if (!Mouse.current.middleButton.isPressed)
        {
            return;
        }
        Vector2 mouseValue = Mouse.current.position.ReadValue();
        Plane plane = new Plane(_planeNormal, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(mouseValue);
        
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
        DragCameraSendToClient(mouseValue);
    }

    private void DragCameraSendToClient(Vector2 mousePosition)
    {
        var mousePositionString = string.Format(CultureInfo.InvariantCulture, "p_{0};{1}", mousePosition.x, mousePosition.y);
        _fmManager.SendToOthers(mousePositionString);
    }

    private Vector3 GetCameraRight()
    {
        Vector3 right = _cameraTransform.right;
        right.y = 0f;
        return right;
    }

    private Vector3 GetCameraForward()
    {
        Vector3 forward = _cameraTransform.forward;
        forward.y = 0f;
        return forward;
    }

    private Vector3 GetCameraUp()
    {
        Vector3 up = _cameraTransform.up;
        up.z = 0f;
        return up;
    }
}
