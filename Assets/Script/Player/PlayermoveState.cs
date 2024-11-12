using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerState
{
    void EnterState();
    void ExitState();
    void ExecuteOnUpdate();


}


//�÷��̾��� ��� ���� 
public class IdleState : IPlayerState
{

    private readonly Move _playerMove;

    //������ : �÷��̾� �ν��Ͻ� �ʱ�ȭ 
    public IdleState(Move playerMove)
    {
        this._playerMove = playerMove;
    }

    public void EnterState()
    {
        _playerMove.animator_Player.SetBool("isMove", false);
        _playerMove.animator_Player.SetFloat("MoveX", 0);
        _playerMove.animator_Player.SetFloat("MoveY", 0);
        _playerMove. animator_Player.SetBool("LevelUp", false);
    }


    public void ExecuteOnUpdate()
    {

        // _playerMove.handleJump();
        if (_playerMove == null)
        { return; }
        else
            _playerMove.PlayerMove(Vector3.zero);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _playerMove.ChangeState(new WalkState(_playerMove));
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMove.ChangeState(new JumpState(_playerMove));
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
        this._playerMove = playerMove;
    }


    public void EnterState()
    {
        _playerMove.animator_Player.SetBool("isMove", true);


    }

    public void ExecuteOnUpdate()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _playerMove.animator_Player.SetFloat("MoveX", 0);
            _playerMove.animator_Player.SetFloat("MoveY", 3);
            direction += _playerMove.transform.forward;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            _playerMove.animator_Player.SetFloat("MoveX", 0);
            _playerMove.animator_Player.SetFloat("MoveY", -3);
            direction += -_playerMove.transform.forward;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _playerMove.animator_Player.SetFloat("MoveX", -3);
            _playerMove.animator_Player.SetFloat("MoveY", 0);
            direction += -_playerMove.transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _playerMove.animator_Player.SetFloat("MoveX", 3);
            _playerMove.animator_Player.SetFloat("MoveY", 0);
            direction += _playerMove.transform.right;
        }
        else
        {
            _playerMove.ChangeState(new IdleState(_playerMove));
        }

        UImanger.Instance.PlayerSliderbarHgUse(0.005f);

        // �̵� ���� ȣ��
        _playerMove.PlayerMove(direction);

        _playerMove.MoveSound.clip = _playerMove.MoveClips[0];


    }


    public void ExitState()
    {

    }



}


//���� 
public class JumpState : IPlayerState
{

    private readonly Move _playerMove;


    public JumpState(Move playerMove)
    {
        this._playerMove = playerMove;
    }

    public void EnterState()
    {
        _playerMove.animator_Player.SetBool("Jump", true);

    }

    public void ExecuteOnUpdate()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += _playerMove.transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += -_playerMove.transform.forward;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction += -_playerMove.transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction += _playerMove.transform.right;
        }

        // ���� �� �̵� ó��
        _playerMove.PlayerMove(direction);

        if (_playerMove.characterController.isGrounded)
        {
            _playerMove.ChangeState(new IdleState(_playerMove));
        }

        _playerMove.MoveSound.clip = _playerMove.MoveClips[1];
        _playerMove.MoveSound.Play();
    }

    public void ExitState()
    {
        _playerMove.animator_Player.SetBool("Jump", false);

    }
}


//���� ���� 
public class AtKState : IPlayerState
{

    private readonly Move _playerMove;



    public AtKState(Move playerMove)
    {
        this._playerMove = playerMove;
    }
    public void EnterState()
    {
        _playerMove.animator_Player.SetTrigger("Attack");
        _playerMove.particle.Play();
    }

    public void ExecuteOnUpdate()
    {
        _playerMove.PlayerMove(Vector3.zero);
        _playerMove.particle.Stop();

        if (!Input.GetMouseButtonDown(0))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                _playerMove.ChangeState(new WalkState(_playerMove));
            }
            else
            {
                _playerMove.ChangeState(new IdleState(_playerMove));

            }

        }



    }

    public void ExitState()
    {

    }




}


public class LevelUP : IPlayerState
{

    private readonly Move _playerMove;



    public LevelUP(Move playerMove)
    {
        this._playerMove = playerMove;
    }
    public void EnterState()
    {
       
    }


    public void ExecuteOnUpdate()
    {
        _playerMove.PlayerMove(Vector3.zero);
        _playerMove.gravity = 1;
        _playerMove.animator_Player.Play("LevelUp");
        _playerMove.animator_Player.SetBool("LevelUp", true);

    }

    public void ExitState()
    {
        Debug.Log("��");

        _playerMove.animator_Player.Play("Defend");
    }




}
