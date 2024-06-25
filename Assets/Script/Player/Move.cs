using System;
using UnityEditor.VersionControl;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public float gravity = -0.5f;

    private float verticalVelocity;
    private bool isGround;

    private CharacterController characterController;
    public Animator animator_Player;
    private IPlayerState currentState;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    /*
    public float moveSpeed = 5f;
  
    public float jumpForce = 5f;

    public float gravity = -0.5f;

    private float VerticalValocity;

    private bool isGround; 

    private CharacterController characterController;
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        Vector3 move = Vector3.zero;



        // 쉬프트 키가 눌렸는지 여부를 확인
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 7.5f;
        }
        else 
        {
            moveSpeed = 5;        
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 3);

            move += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -3);

            move += -transform.forward;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("MoveX", -3);
            animator.SetFloat("MoveY", 0);

            move += -transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("MoveX", 3);
            animator.SetFloat("MoveY", 0);

            move += transform.right;
        }
        else
        {
            animator.SetBool("isMove", false);
        }

     
        isGround =characterController.isGrounded;
        if (isGround)
        {
            Debug.Log("땅이야");
        }
        if (isGround && VerticalValocity < 0)
        { 
           VerticalValocity = 0f;
            animator.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            VerticalValocity = jumpForce;
            animator.SetBool("Jump", true);
        }
        VerticalValocity += gravity + Time.deltaTime;
        move.y = VerticalValocity;

        characterController.Move(move * moveSpeed * Time.deltaTime);
        
    }

    */


    private void Start()
    {
        isGround = characterController.isGrounded;
        ChangeState(new IdleState(this));
    }

    private void Update()
    {
        currentState?.ExtcuteOnUpdate();

    }


    public void ChangeState(IPlayerState newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();


    }

    public void PlayerMove(Vector3 direction)
    {
        Vector3 move = direction * moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= moveSpeed;
        }
        move.y = verticalVelocity;
        characterController.Move(move * Time.deltaTime);
    }

    public void handleJump()
    {
        isGround = characterController.isGrounded;

        if (isGround && verticalVelocity < 0)
        { 
          verticalVelocity = 0f;
            animator_Player.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            verticalVelocity = jumpForce;
            animator_Player.SetBool("Jumo", true);
        }

        verticalVelocity += gravity * Time.deltaTime;
    
    
    }


}
