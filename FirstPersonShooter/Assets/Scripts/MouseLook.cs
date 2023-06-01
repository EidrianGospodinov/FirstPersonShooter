using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(50f, 500f)]
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//makes sure that mu mouse doesnt leave the window
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //this is making the y rotation always start from the x position so you rotate from the way you face
        xRotation -= mouseY;

        //Math.clamp is limiting the rotation for looking down and up to 90 degree
        xRotation=Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation=Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);
       
    }
}
