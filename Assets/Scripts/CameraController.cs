using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Description("The camera template")]
    private Transform CameraTemplate;

    [SerializeField] [Description("horizontal rotation speed in meters per second.")]
    private float LockedCameraRotationSpeed = 180.0f;

    [SerializeField]
    [Description("free flight drag rotation speed in meters per second.")]
    private float FreeCameraRotationSpeed = 360.0f;

    [SerializeField]
    [Description("Free flight camera movement speed in meters per second.")]
    private float FlightMovementSpeed = 10.0f;


    [SerializeField]
    [Description("up/down translation speed in meters per second.")]
    private float TranslationSpeed = 5.0f;

    [SerializeField]
    [Description("up/down translation speed in meters per second.")]
    private float MinCameraHeight = 5.0f;

    [SerializeField]
    [Description("up/down translation speed in meters per second.")]
    private float MaxCameraHeight = 20.0f;

    [SerializeField]
    [Description("How fast we should zoom in/out")]
    private float ZoomSensitivity = 2.0f;

    [SerializeField]
    [Description("max zoomed out field of view")]
    private float MinFOV = 15.0f;

    [SerializeField]
    [Description("max zoomed in field of view")]
    private float MaxFOV = 90.0f;

    private Vector3 DragOrigin = Vector3.zero;

    private float DefaultFOV;

    private enum Mode
    {
        Locked,
        Free
    }

    private Mode CameraMode;

    void Start()
    {
        CameraMode = Mode.Free;
        CameraTemplate.transform.LookAt(transform);
        DefaultFOV = Camera.main.fieldOfView;
    }

    GameObject GetTarget()
    {
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
        {
            return null;
        }

        if (!hitInfo.transform || !hitInfo.transform.gameObject)
        {
            return null;
        }

        return hitInfo.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        HandleCameraMode();

        switch (CameraMode)
        {
            case Mode.Free:
                UpdateFreeCamera();
                break;
            case Mode.Locked:
                UpdateLockedCamera();
                break;
        }

    }

    void HandleCameraMode()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        DragOrigin = Input.mousePosition;

        //handle locking to pivot
        GameObject Target = GetTarget();
        if (!Target)
        {
            return;
        }

        if (Target.CompareTag("selectable"))
        {
            CameraMode = Mode.Locked;
            transform.position = Target.transform.position;
            return;

        }

        //when we are locked and click away we want to go into free flight mode
        if (CameraMode == Mode.Locked)
        {
            CameraMode = Mode.Free;
            Camera.main.fieldOfView = DefaultFOV;
            return;
        }

    }

    //TODO: touch drag for rotation
    void UpdateLockedCamera()
    {
        float FieldOfView = Camera.main.fieldOfView;
        FieldOfView += Input.GetAxis("Mouse ScrollWheel") * ZoomSensitivity;
        FieldOfView = Mathf.Clamp(FieldOfView, MinFOV, MaxFOV);
        Camera.main.fieldOfView = FieldOfView;

        transform.RotateAround(transform.position, Vector3.up, -Input.GetAxis("Horizontal") * LockedCameraRotationSpeed * Time.deltaTime);

        CameraTemplate.transform.position = new Vector3(CameraTemplate.transform.position.x, Mathf.Clamp(CameraTemplate.transform.position.y + Input.GetAxis("Vertical") * TranslationSpeed * Time.deltaTime, MinCameraHeight, MaxCameraHeight), CameraTemplate.transform.position.z);
        CameraTemplate.transform.LookAt(transform);
    }

    void UpdateFreeCamera()
    {
        //TODO: drag to rotate camera


        //WASD to move camera around, space + WS for up/down
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(-Input.GetAxis("Horizontal") * FlightMovementSpeed * Time.deltaTime, Input.GetAxis("Vertical") * FlightMovementSpeed * Time.deltaTime, 0), Space.World);
        }
        else
        {
            transform.Translate(new Vector3(-Input.GetAxis("Horizontal") * FlightMovementSpeed * Time.deltaTime, 0, -Input.GetAxis("Vertical") * FlightMovementSpeed * Time.deltaTime), Space.World);
        }

        //Drag to move around
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        if (DragOrigin == Vector3.zero)
        {
            return;
        }
        
        // CameraTemplate.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * FreeCameraRotationSpeed * Time.deltaTime,  0, 0) ,Space.World);
        
        CameraTemplate.Rotate(new Vector3(0, -Input.GetAxis("Mouse X") * FreeCameraRotationSpeed * Time.deltaTime, 0), Space.World);

    }
}
