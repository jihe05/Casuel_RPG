using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerState
{
    void EnterState();
    void ExitState();
    void ExtcuteOnUpdate();

   
}


//�÷��̾��� ��� ���� 
public class IdleState : IPlayerState
{

    private readonly Move _playerMove;

    //������ : �÷��̾� �ν��Ͻ� �ʱ�ȭ 
    public IdleState(Move playerMove)
    {
        _playerMove = playerMove;
    }

    public void EnterState()
    {
        _playerMove.animator_Player.SetBool("isMove" , false);
        _playerMove.animator_Player.SetFloat("MoveX", 0);
        _playerMove.animator_Player.SetFloat("MoveY", 0);
    }


    public void ExtcuteOnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.A))
        {
            _playerMove.ChangeState(new WalkState(_playerMove));
        }
        else
        {
            _playerMove.ChangeState(new IdleState(_playerMove));
        }
    }

    public void ExitState()
    {

    }

}

//�ȱ�
public class WalkState : IPlayerState
{

    private readonly Move _playerMove;
    public WalkState(Move playerMove)
    { 
      _playerMove = playerMove;
    }
    
      
    public void EnterState()
    {
        Debug.Log("�ִϸ��̼�");
        _playerMove.animator_Player.SetBool("isMove", true);
        _playerMove.animator_Player.SetFloat("MoveX", 0);
        _playerMove.animator_Player.SetFloat("MoveY", 3);
    }

    public void ExitState()
    {
      
    }

    public void ExtcuteOnUpdate()
    {
      

    }


}

//�޸���
public class RunState : IPlayerState
{

    private readonly Move _playerMove;
    public RunState(Move playerMove)
    {
        _playerMove = playerMove;
    }

    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void ExtcuteOnUpdate()
    {


    }
}

//���� 
public class JumpState : IPlayerState
{

    private readonly Move _playerMove;
    public JumpState(Move playerMove)
    {
        _playerMove = playerMove;
    }

    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void ExtcuteOnUpdate()
    {


    }
}

//���� ���� 
public class AtKState : IPlayerState
{

    private readonly Move _playerMove;
    public AtKState(Move playerMove)
    {
        _playerMove = playerMove;
    }
    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    public void ExtcuteOnUpdate()
    {


    }

}
