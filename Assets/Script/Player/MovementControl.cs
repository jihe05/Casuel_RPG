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
        // �ڽ� ������Ʈ�� �� �ϳ��� Ȱ��ȭ�Ǿ� �ִ��� üũ
        bool anyChildActive = false;

        foreach (Transform child in this.gameObject.transform)
        {
            // �ڽ� ������Ʈ�� Ȱ��ȭ�Ǿ� ������ �÷��� ����
            if (child.gameObject.activeSelf)
            {
                anyChildActive = true;
                break; // Ȱ��ȭ�� ������Ʈ�� �ϳ��� ������ ���� ����
            }
        }

        // �ϳ��� Ȱ��ȭ�� ��� �÷��̾��� �������� ��Ȱ��ȭ
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
            // ��� �ڽ� ������Ʈ�� ��Ȱ��ȭ�� ���
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

