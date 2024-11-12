using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public void MoveToNewParentButton(Transform newParent)
    {
        // 부모를 변경합니다.
        transform.SetParent(newParent);
        Move move = GetComponentInParent<Move>();

        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;

        if (move != null)                                                                                                           
        {
            move.OnAnimatorPlayer(gameObject);
            newParent.GetComponent<Move>().enabled = true;
        }
        else
            Debug.Log("오브젝트를 찾을 수 없습니다.");
    }




}
