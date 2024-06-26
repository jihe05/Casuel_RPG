using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SelectCamaraMove : MonoBehaviour
{
   
    bool isMove = false;


    void Update()
    {

        if (isMove)
        {
         
            Vector3 newMove = transform.position;
            Debug.Log(newMove);
            newMove.x -= 2;
            Debug.Log(newMove.x);
            newMove = new Vector3(newMove.x, transform.position.y, transform.position.z);
            transform.position = newMove;
            Debug.Log(transform.position);
        }
        StopMoving();
    }

    // 호출될 때마다 움직이기 시작
    public void MoveLeft()
    {
        isMove = true;
    }


    // 움직임을 멈추는 함수
    public void StopMoving()
    {
        isMove = false;
    }


}
