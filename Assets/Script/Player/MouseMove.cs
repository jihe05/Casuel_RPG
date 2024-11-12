using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float mouseSpeed = 200f;
    public float xRotation = 0f;

    public Transform plauyerObj;

    public void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;

        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            //카메라X축 제한
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40f, 40f);

        plauyerObj.Rotate(Vector3.up * mouseX);


        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


    }

}