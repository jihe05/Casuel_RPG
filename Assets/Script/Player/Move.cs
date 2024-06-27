using System;
using UnityEditor.VersionControl;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float gravity = -23f;
    private int count =0;
   
    private float verticalVelocity;//수직속도
  

    public CharacterController characterController;

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
        ChangeState(new IdleState(this));
    }

    private void Update()
    {

        currentState?.ExtcuteOnUpdate();

        // 마우스 클릭 시 공격 상태로 전환
        if (Input.GetMouseButtonDown(0) && !(currentState is AtKState))
        {
            ChangeState(new AtKState(this));
            PlayerAttackCount();
        }

    }

    private void PlayerAttackCount()
    {
        if (count <= 2)
            count++;
        else
            count = 0;
        
        animator_Player.SetInteger("AttackCount", count);

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
            move *= 2;
        }

        if (characterController.isGrounded)
        {
            if (verticalVelocity < 0)
            {
                verticalVelocity = 0f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
                animator_Player.SetBool("Jump", true);
              
            }
          
        }
        else
        {
            animator_Player.SetBool("Jump", false);
            verticalVelocity += gravity * Time.deltaTime;   
        }

        move.y = verticalVelocity;
        characterController.Move(move * Time.deltaTime);
    }

    public void OnAnimatorPlayer(GameObject player)
    {
        Debug.Log("호출");
        animator_Player = player.GetComponent<Animator>();

        if (animator_Player != null)
        {
            Debug.Log(321);
        }
        else
        {
            Debug.LogWarning("Animator component not found on the player object.");
        }
    }

}
