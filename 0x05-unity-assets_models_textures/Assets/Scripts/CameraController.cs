using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset; // Distance of camera
    public bool lockCursor;
    public float MouseSense = 10;
    public Transform target;
    public float distanceFromTarget = 2; // to know how far the camera should be from the target
    public Vector2 PitchMinMax = new Vector2(-40, 85); // for the clamp
    public float RotationSmoothTime = .12f; // For smooth time
    
    Vector3 RotationSmoothVelocity; // Smooth velocity
    Vector3 ActualRotation;
    
    float pitch; // x axis
    float yaw; // y axis

   void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Called after all other update methods
    void LateUpdate()
    {
        transform.position = target.position - offset;
        yaw += Input.GetAxis("Mouse X") * MouseSense; //Horizontal mouse movement
        pitch -= Input.GetAxis("Mouse Y") * MouseSense; //Mouse y
        
        pitch = Mathf.Clamp(pitch, PitchMinMax.x, PitchMinMax.y); // Returns float between min and max
        
        ActualRotation = Vector3.SmoothDamp(ActualRotation, new Vector3(pitch, yaw), ref RotationSmoothVelocity, RotationSmoothTime); //Smoothly move the camera towards target position
        
        transform.eulerAngles = ActualRotation;
        transform.position = target.position - transform.forward * distanceFromTarget;

    }
}
