using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.InputSystem.LowLevel;

//보스 STATE(대기, 걷기, 하늘에서 공격,막기, 일반공격, 물기, 맞음, 죽음 )
enum BossState
{ 
      IDLE,
      WALK,
      FLYATTACK,
      CLAWATTACK,
      BASICATTACK,
      DEFEND,
      DIE
     
}

public class Bossmove : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navMesh;
    Move player;
    Transform Target;
    float distanceToPlayer;


    [Header("Range")]
    public float closeAttackRange = 15f;
    public float mediumAttackRange = 15f;
    public float attackInterval = 5f;
    public float Hp = 100000f;
    public float Ap = 500;
    private bool flyAttackUsed = false;

    BossState state;
    float nextAttaclTime;

    private void Awake()
    {
        player = FindObjectOfType<Move>();
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();

        
    }

    private void Start()
    {
        state = BossState.IDLE;
    }

    private void Update()
    {
        if (Target != null)
            Target = player.transform;
        if (Target == null)
            return;

        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        // 목표를 계속 추적
        navMesh.SetDestination(Target.position);
        // 목표를 바라보도록 회전
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);


        switch (state)
        {
          case BossState.IDLE:
                IdleSate();
                break;
            case BossState.WALK:
                WalkState();
                break;
            case BossState.FLYATTACK:
                FlyAttackState();
                break;
            case BossState.CLAWATTACK:
                ClawattackState();
                break;
            case BossState.BASICATTACK:
                BasicAttackState();
                break;
            case BossState.DEFEND:
                DefendState();
                break;
            case BossState.DIE:
                DieState();
                break;

        }

        if (Target == null)
            return;


        if (Hp == 0 && state != BossState.DIE)
        {
            ChangeState(BossState.DIE);
        }


    }

    private void ChangeState(BossState newState)
    {
        state = newState;
        animator.SetInteger("state", (int)newState);
    }

    public void IdleSate()
    {
        //플레이어가 멀리 떨어지면 WAlk
        if (distanceToPlayer < mediumAttackRange)
        {
            ChangeState(BossState.WALK);
        }
    }

    public void WalkState()
    {
        animator.CrossFade(BossState.WALK.ToString(), 0.1f);

        if (distanceToPlayer <= 10)
        {
            PerformAttack();
        }
        else
        {
            navMesh.SetDestination(Target.position);
        }

       
    }

    public void PerformAttack()
    {
        
     
        //플레이어와의 거리가 10이하일때
        if (distanceToPlayer <= closeAttackRange)
        {
            // 가까운 거리일 때 Claw Attack 또는 다른 공격 확률적으로 선택
            int randomValue = Random.Range(0, 100);
            if (randomValue < 60) // 70% 확률로 Claw Attack
            {
                ChangeState(BossState.CLAWATTACK);
            }
            else // 30% 확률로 Basic Attack
            {
                ChangeState(BossState.BASICATTACK);
            }
        }
        else if (distanceToPlayer > closeAttackRange)
        {
            ChangeState(BossState.WALK);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            if (state == BossState.BASICATTACK)
            {
                PlayerManager.instance.PlayerUpdateHp(Ap);
            
            }

        }
    }



    public void FlyAttackState()
    {
        if (Time.time >= nextAttaclTime)
        { 
            nextAttaclTime = Time.time + attackInterval;
            ChangeState(BossState.WALK);
        }
    }

    public void ClawattackState()
    {
        if (Time.time >= nextAttaclTime)
        {
            nextAttaclTime = Time.time + attackInterval;
            ChangeState(BossState.WALK);
        }
       

    }

    public void DefendState()
    {
        if (Time.time >= nextAttaclTime)
        {
            nextAttaclTime = Time.time + attackInterval;
            ChangeState(BossState.WALK);
        }
      
    }

    public void BasicAttackState()
    {
        if (Time.time >= nextAttaclTime)
        {
            nextAttaclTime = Time.time + attackInterval;

            ChangeState(BossState.WALK);

        }

    }

 
    public void DieState()
    {
        animator.Play("Die");
        Destroy(gameObject, 2f);
        
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
            ChangeState(BossState.WALK);
        }
    }

    public void UpdateHp(float damage)
    {
       

        Hp -= damage;

        if (Hp <= 0)
        {
            ChangeState(BossState.DIE);
        }
        // 체력이 절반 이하일 때 Fly Attack 실행
        else if (Hp <= 50 && !flyAttackUsed)
        {
            flyAttackUsed = true;
            ChangeState(BossState.FLYATTACK);
        }
        else
        {
          
             animator.Play("Defend");
             ChangeState(BossState.DEFEND);
            
           
        }
    }
}
