using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCamaraMove : MonoBehaviour
{

    public Camera mainCamera; // 메인 카메라
   
    private float moveAmount = 2.0f; // 초기 이동량


    public void MoveCameraLeft()
    {
       
        
            // 이동 전 포지션 출력
            Debug.Log("Camera Position before move left: " + mainCamera.transform.position);

            Vector3 newPosition = mainCamera.transform.position;
            newPosition.x -= moveAmount; // X 값만 변경
            mainCamera.transform.position = newPosition;

            // 이동 후 포지션 출력
            Debug.Log("Camera moved left to: " + newPosition);

            // 이동량을 감소시킴
            moveAmount *= 0.9f; // 이동량을 10%씩 감소시킴
        
    }

    public void MoveCameraRight()
    {
       
        
            // 이동 전 포지션 출력
            Debug.Log("Camera Position before move right: " + mainCamera.transform.position);

            Vector3 newPosition = mainCamera.transform.position;
            newPosition.x += moveAmount; // X 값만 변경
            mainCamera.transform.position = newPosition;

            // 이동 후 포지션 출력
            Debug.Log("Camera moved right to: " + newPosition);

            // 이동량을 감소시킴
            moveAmount *= 0.9f; // 이동량을 10%씩 감소시킴
        
    }



}
