using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float mouseSpeed = 200f;
    public float xRotation = 0f;

    public Transform plauyerObj;

 

    public void Update()
    {

        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.identity;

            float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            //ī�޶�X�� ����
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -40f, 20f);



            plauyerObj.Rotate(Vector3.up * mouseX);

        }



    }

}