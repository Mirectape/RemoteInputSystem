using System.Collections;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    private CameraControlActions _controlMaps;
    private Coroutine _zoomCoroutine;
    private Transform _cameraTransform;

    [SerializeField]
    private float _cameraSpeed = 8f;

    private void Awake()
    {
        _controlMaps = new CameraControlActions();
        _cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        _controlMaps.Enable();
    }

    private void Start()
    {
        _controlMaps.TouchScreen.SecondaryTouchContact.started += _ => ZoomStart();
        _controlMaps.TouchScreen.SecondaryTouchContact.canceled += _ => ZoomEnd();
    }

    private void ZoomStart()
    {
        _zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd()
    {
        StopCoroutine(ZoomDetection());
    }

    IEnumerator ZoomDetection()
    {
        float distance = 0f; // b/n fingers, for inst 
        float previousDistance = 0f;
        while(true)
        {
            distance = Vector2.Distance(_controlMaps.TouchScreen.PrimaryFingerPosition.ReadValue<Vector2>(),
                _controlMaps.TouchScreen.SecondaryFingerPosition.ReadValue<Vector2>());

            // detection
            if(distance > previousDistance) // zooming out
            {
                Vector3 targetPostion = _cameraTransform.position;
                targetPostion.z -= 1f; // delta to move away = minus sign of z
                _cameraTransform.position = Vector3.Slerp(_cameraTransform.position, targetPostion, Time.deltaTime * _cameraSpeed);
            }
            else if(distance < previousDistance) // zooming in
            {
                Vector3 targetPostion = _cameraTransform.position;
                targetPostion.z += 1f; // delta to move in = plus sign of z
                _cameraTransform.position = Vector3.Slerp(_cameraTransform.position, targetPostion, Time.deltaTime * _cameraSpeed);
            }

            // keep track of previous distance for next loop
            previousDistance = distance;
            yield return null;
        }
    }
}
