using Ivnentory;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{



    //현재 상태 정의 
    private IPlayerState _playerState;

    //입력 콜백 액션 (인풋시스템의 호출의 따라 액션)
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

       

        //초기상태를 Idel로 설정
        ChageState(new IdleState(this));

    }

    public void ChageState(IPlayerState newState)
    {
        _playerState?.ExitState();//현재 상태 종료
        _playerState = newState;//새로운 상태 변경
        _playerState.EnterState();//새로운 상태 진입
    }

    //입력 콜백 바인딩/ 해제 바인딩
    public void BindinputCallback(bool isBind, Action<InputAction.CallbackContext> callback)
    {
        if (isBind)
        {
            _inpuctCallback += callback;//콜백 추가 

        }
        else
        {
            
            _inpuctCallback -= callback;// 콜백제거
        }
    
    }
   

}
