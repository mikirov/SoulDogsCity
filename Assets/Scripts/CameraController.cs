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

    [SerializeField] [Description("horizontal rotation speed in meters per second.")]
    private float CameraMovementSpeed = 180.0f;

    [SerializeField]
    [Description("up/down translation speed in meters per second.")]
    private float TranslationSpeed = 5.0f;

    [SerializeField]
    [Description("up/down translation speed in meters per second.")]
    private float MinCameraHeight = 5.0f;

    [SerializeField]
    [Description("up/down translation speed in meters per second.")]
    private float MaxCameraHeight = 20.0f;


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
        }

        transform.RotateAround(transform.position, Vector3.up, -Input.GetAxis("Horizontal") * CameraMovementSpeed * Time.deltaTime);

        CameraTemplate.transform.position = new Vector3(CameraTemplate.transform.position.x, Mathf.Clamp(CameraTemplate.transform.position.y + Input.GetAxis("Vertical") * TranslationSpeed * Time.deltaTime, MinCameraHeight, MaxCameraHeight), CameraTemplate.transform.position.z );
        CameraTemplate.transform.LookAt(transform);
    }
}
