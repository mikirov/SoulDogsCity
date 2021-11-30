using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] [Description("the thing we want to rotate around.")]
    private Transform DefaultPivot;

    [SerializeField]
    [Description("The camera template")]
    private Transform CameraTemplate;

    [SerializeField] [Description("Camera speed in meters per second.")]
    private float CameraMovementSpeed = 40.0f;

    void Start()
    {
        if (DefaultPivot == null)
        {
            Debug.Log("Default pivot not set. Please set it in the camera script.");
            return;
        }
        transform.position = DefaultPivot.position;
        CameraTemplate.transform.LookAt(transform);
    }

    Transform GetNewTransform()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return null;
        }

        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
        {

            return null;
        }

        if (!hitInfo.transform || !hitInfo.transform.gameObject)
        {
            return null;
        }
        if (!hitInfo.transform.gameObject.CompareTag("selectable"))
        {
            return null;
        }

        return hitInfo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Transform PivotCandidate = GetNewTransform();
        if (PivotCandidate)
        {
            transform.position = PivotCandidate.position;
            CameraTemplate.transform.LookAt(transform);
        }

        float DeltaVerticalAngle = Input.GetAxis("Vertical") * CameraMovementSpeed * Time.deltaTime;
        float VerticalRotationAngle =
            (CameraTemplate.transform.rotation.eulerAngles.x + DeltaVerticalAngle < 45 &&
             CameraTemplate.transform.rotation.eulerAngles.x + DeltaVerticalAngle > 5)
                ? DeltaVerticalAngle
                : 0.0f;


        CameraTemplate.transform.RotateAround(transform.position, Vector3.left, VerticalRotationAngle);

        CameraTemplate.transform.RotateAround(transform.position, Vector3.down, Input.GetAxis("Horizontal") * CameraMovementSpeed * Time.deltaTime);


        Vector3 relativePos = transform.position - CameraTemplate.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        CameraTemplate.rotation = rotation;
    }
}
