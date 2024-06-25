using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerState
{
    void EnterState();
    void ExitState();
    void ExtcuteOnUpdate();

   
}


//플레이어의 대기 상태 
public class IdleState : IPlayerState
{

    private readonly Move _playerMove;

    //생성자 : 플레이어 인스턴스 초기화 
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

//걷기
public class WalkState : IPlayerState
{

    private readonly Move _playerMove;
    public WalkState(Move playerMove)
    { 
      _playerMove = playerMove;
    }
    
      
    public void EnterState()
    {
        Debug.Log("애니메이션");
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

//달리기
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

//점프 
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

//공격 상태 
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
