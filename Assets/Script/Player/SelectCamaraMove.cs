using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCamaraMove : MonoBehaviour
{

    public Camera mainCamera; // ���� ī�޶�
   
    private float moveAmount = 2.0f; // �ʱ� �̵���


    public void MoveCameraLeft()
    {
       
        
            // �̵� �� ������ ���
            Debug.Log("Camera Position before move left: " + mainCamera.transform.position);

            Vector3 newPosition = mainCamera.transform.position;
            newPosition.x -= moveAmount; // X ���� ����
            mainCamera.transform.position = newPosition;

            // �̵� �� ������ ���
            Debug.Log("Camera moved left to: " + newPosition);

            // �̵����� ���ҽ�Ŵ
            moveAmount *= 0.9f; // �̵����� 10%�� ���ҽ�Ŵ
        
    }

    public void MoveCameraRight()
    {
       
        
            // �̵� �� ������ ���
            Debug.Log("Camera Position before move right: " + mainCamera.transform.position);

            Vector3 newPosition = mainCamera.transform.position;
            newPosition.x += moveAmount; // X ���� ����
            mainCamera.transform.position = newPosition;

            // �̵� �� ������ ���
            Debug.Log("Camera moved right to: " + newPosition);

            // �̵����� ���ҽ�Ŵ
            moveAmount *= 0.9f; // �̵����� 10%�� ���ҽ�Ŵ
        
    }



}
