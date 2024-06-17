using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();   
    }
    private void Update()
    {
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


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("F"))
        {

           UImanger.Instance.OpenAndCloseShop();
           
        }
    }

}
