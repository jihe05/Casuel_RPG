using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

//보스 STATE(대기, 걷기, 하늘에서 공격,막기, 일반공격, 물기, 맞음, 죽음 )
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

        // 목표를 바라보도록 회전
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // 목표를 계속 추적
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
