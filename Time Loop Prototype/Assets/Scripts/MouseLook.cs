using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivityY = 300f;
    public float mouseSensitivityX = 200f;

    public Transform playerBody;
    float xRotation = 0f;
    float initXRotation = 9f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX, Space.Self);
        xRotation -= mouseY;
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        xRotation = Mathf.Clamp(xRotation, initXRotation - 15f, initXRotation + 15f);
    }
}
