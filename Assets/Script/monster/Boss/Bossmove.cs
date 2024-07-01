using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

//���� STATE(���, �ȱ�, �ϴÿ��� ����,����, �Ϲݰ���, ����, ����, ���� )
enum BossState
{ 
      IDLE,
      WALK,
      FLYATTACK,
      CLAWATTACK,
      DEFEND,
      BASICATTACK,
      HIT,
      DIE
     
}

public class Bossmove : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navMesh;
    Move player;
    Transform Target;


    BossState state;

    private void Awake()
    {
        player = GetComponent<Move>();
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();

        if(Target != null)
        Target = player.transform;

    }

    private void Start()
    {
        state = BossState.IDLE;
    }

    private void Update()
    {
        switch (state)
        {
          case BossState.IDLE:
                Idle();
                break;
            case BossState.WALK:
                Walk();
                break;
            case BossState.FLYATTACK:
                FlyAttack();
                break;
            case BossState.CLAWATTACK:
                Clawattack();
                break;
            case BossState.DEFEND:
                Defend();
                break;
            case BossState.BASICATTACK:
                BasicAttack();
                break;
            case BossState.HIT:
                Hit();
                break;
            case BossState.DIE:
                Die();
                break;

        }

        if (Target == null)
            return;

        // ��ǥ�� �ٶ󺸵��� ȸ��
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // ��ǥ�� ��� ����
        navMesh.SetDestination(Target.position);

        //if (MonsterHP == 0 && state != BossState.DIE)
        //{

        //    ChangeState(BossState.DIE);
        //}
       

    }
    private void StateChainge(BossState newState)
    {
        animator.SetInteger("state", (int)newState);
    }

    public void Idle()
    {
        state = BossState.IDLE;
    }

    public void Walk()
    {
        
       
    }

    public void FlyAttack()
    {
       
    }

    public void Clawattack()
    {
        
       
    }

    public void Defend()
    {
       
      
    }

    public void BasicAttack()
    {
      
      
    }

    public void Hit()
    {
      
     
    }

    public void Die()
    {
       
        
    }


    public void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        else
        {
            Target = other.transform;
            navMesh.SetDestination(Target.position);
            StateChainge(BossState.WALK);
        }
    }


}
