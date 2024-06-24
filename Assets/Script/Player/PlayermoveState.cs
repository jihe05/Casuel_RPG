using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public interface IPlayerState
{
    void EnterState();
    void ExitState();
    void ExtcuteOnUpdate();

    void OnInputCallback(InputAction.CallbackContext context);
}

//모든 생태가 구현되야 하는 메서드 정의
public class StatePlayerBase : IPlayerState
{
    public virtual void EnterState() 
    {

    }
    public virtual void ExitState()
    { 
    
    }
    public virtual void ExtcuteOnUpdate()
    {
    
    }

    public virtual void OnInputCallback(InputAction.CallbackContext context) 
    {
        
    }

}

//플레이어의 대기 상태 
public class IdleState : StatePlayerBase
{  
    //플레이어의 행동을 관리하는 인스턴스
   private readonly Move _playerMove;

    //생성자 : 플레이어 인스턴스 초기화 
    public IdleState(Move playerMove)
    {
        this._playerMove = playerMove;
    }

    public override void EnterState()
    {
        _playerMove.BindinputCallback(true, OnInputCallback);//입력 콜백을 바인딩
    }

    public override void ExitState()
    {
        
    }

    public override void OnInputCallback(InputAction.CallbackContext context)
    {
          
    }
}
public class AtKState : StatePlayerBase
{ 


}

public class JumpState : StatePlayerBase
{ 


}

public class RunState : StatePlayerBase
{ 


}



