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

    // ȣ��� ������ �����̱� ����
    public void MoveLeft()
    {
        isMove = true;
    }


    // �������� ���ߴ� �Լ�
    public void StopMoving()
    {
        isMove = false;
    }


}
