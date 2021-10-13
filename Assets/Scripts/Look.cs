using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Gives the player the ability to use the mouse to rotate a player object in a first person fashion.

    This should be attached to an object with a camera child object. It will rotate the entire object horizontally, and the camera vertically. 
*/

public class Look : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1.0f;
    [SerializeField] private Transform cameraTransform = null;

    public bool blockRot = false; //If true no rotation will be applied to the player

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    float yRot = 0.0f;

    // Calling this in LateUpdate prevents jitter while moving
    void LateUpdate()
    {
        if (blockRot)
            return;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        yRot -= mouseY;
        yRot = Mathf.Clamp(yRot, -90, 90);

        transform.Rotate(Vector3.up * mouseX);
        cameraTransform.transform.localRotation = Quaternion.Euler(yRot, 0, 0);
    }
}