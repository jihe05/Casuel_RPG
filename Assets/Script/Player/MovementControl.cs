using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControl : MonoBehaviour
{
    public MouseMove mouseMove;
    public Move move;

    
    private void Update()
    {
        // 자식 오브젝트들 중 하나라도 활성화되어 있는지 체크
        bool anyChildActive = false;

        foreach (Transform child in this.gameObject.transform)
        {
            // 자식 오브젝트가 활성화되어 있으면 플래그 설정
            if (child.gameObject.activeSelf)
            {
                anyChildActive = true;
                break; // 활성화된 오브젝트가 하나라도 있으면 루프 종료
            }
        }

        // 하나라도 활성화된 경우 플레이어의 움직임을 비활성화
        if (anyChildActive)
        {
            if(mouseMove != null)
            mouseMove.enabled = false;

            if (move != null)
            {
                move.Rgb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                
                move.enabled = false;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            // 모든 자식 오브젝트가 비활성화된 경우
            if (mouseMove != null)
                mouseMove.enabled = true;
            if (move != null)
            {
                  move.Rgb.constraints = RigidbodyConstraints.FreezeRotation;
               move.enabled = true;
            }
        
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if (mouseMove != null)
                    mouseMove.enabled = false;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    
    }

    
}

