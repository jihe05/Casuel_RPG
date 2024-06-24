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

//��� ���°� �����Ǿ� �ϴ� �޼��� ����
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

//�÷��̾��� ��� ���� 
public class IdleState : StatePlayerBase
{  
    //�÷��̾��� �ൿ�� �����ϴ� �ν��Ͻ�
   private readonly Move _playerMove;

    //������ : �÷��̾� �ν��Ͻ� �ʱ�ȭ 
    public IdleState(Move playerMove)
    {
        this._playerMove = playerMove;
    }

    public override void EnterState()
    {
        _playerMove.BindinputCallback(true, OnInputCallback);//�Է� �ݹ��� ���ε�
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



