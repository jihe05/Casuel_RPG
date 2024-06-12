using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;



public class Move : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 moveInput;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    public void OnMove(InputValue inputValue)
    {
        Debug.Log("°£´ç!");
        animator.SetBool("isMove", true);
        moveInput = inputValue.Get<Vector2>();

    }


    private void FixedUpdate()
    {
        Debug.Log($"X¿Í Y :{moveInput.x},{moveInput.y}");

        Vector3 movement = new Vector2(moveInput.x, moveInput.y) * speed * Time.fixedDeltaTime;

        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);

        if (moveInput.x == 0 && moveInput.y == 0)
        {
            animator.SetBool("isMove", false);
        }

    }

   

}
