using Ivnentory;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{



    //���� ���� ���� 
    private IPlayerState _playerState;

    //�Է� �ݹ� �׼� (��ǲ�ý����� ȣ���� ���� �׼�)
    private Action<InputAction.CallbackContext> _inpuctCallback;


    

   

    private void Update()
    {
        /*
        animator.SetBool("isMove", false);
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 3);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -3);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("MoveX", -3);
            animator.SetFloat("MoveY", 0);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("MoveX", 3);
            animator.SetFloat("MoveY", 0);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        */

       

        //�ʱ���¸� Idel�� ����
        ChageState(new IdleState(this));

    }

    public void ChageState(IPlayerState newState)
    {
        _playerState?.ExitState();//���� ���� ����
        _playerState = newState;//���ο� ���� ����
        _playerState.EnterState();//���ο� ���� ����
    }

    //�Է� �ݹ� ���ε�/ ���� ���ε�
    public void BindinputCallback(bool isBind, Action<InputAction.CallbackContext> callback)
    {
        if (isBind)
        {
            _inpuctCallback += callback;//�ݹ� �߰� 

        }
        else
        {
            
            _inpuctCallback -= callback;// �ݹ�����
        }
    
    }
   

}
