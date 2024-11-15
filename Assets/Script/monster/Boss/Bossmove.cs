using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    public static Bossmove Instance;

    [Header("Range")]
    [SerializeField] private Transform Target;
    [SerializeField] private NavMeshAgent nmAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Fire;
    [SerializeField] private Slider HpSlider;


    [SerializeField] private float Hp;
    [SerializeField] private float Ap;
    [SerializeField] private float closeAttackRange;
    [SerializeField] private float mediumAttackRange;
    [SerializeField] float attackInterval;
    private float nextAttackTime;
    private float distanceToPlayer;

    private BossState state;

    private void Awake()
    {
        if (Fire == null)
        {
            return;
        }
        Fire.gameObject.SetActive(false);
        nmAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        Instance = this;

        // �⺻ ���� �� ����
        closeAttackRange = 15f;
        mediumAttackRange = 15f;
        attackInterval = 5f;
        Hp = 10000f;
        Ap = 500f;
    }

    private void Start()
    {
        state = BossState.IDLE;
        StartCoroutine(StateMachine());

        // HP �����̴� ���� �� �ʱ�ȭ
        UImanger.Instance.BossSliderbar(Hp);
        HpSlider = GetComponentInChildren<Slider>();
    }

    IEnumerator StateMachine()
    {
        while (Hp > 0)
        {
            yield return StartCoroutine(state.ToString());
        }

        // HP�� 0 ������ �� DIE ���·� ��ȯ
        if (Hp <= 0)
        {
            ChangeState(BossState.DIE);
            yield return StartCoroutine(state.ToString());
        }
    }

    IEnumerator IDLE()
    {
        var curAnimStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (!curAnimStateInfo.IsName("Idle"))
            animator.Play("Idle", 0, 0);

        // �÷��̾ �ٶ󺸵��� ȸ��
        if (Target != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, Target.position);
            Vector3 direction = (Target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        if (distanceToPlayer < mediumAttackRange)
        {
            ChangeState(BossState.WALK);
        }

        yield return null;
    }

    IEnumerator WALK()
    {
        animator.CrossFade(BossState.WALK.ToString(), 0.1f);

        if (Target != null)
        {
            nmAgent.SetDestination(Target.position);
            distanceToPlayer = Vector3.Distance(transform.position, Target.position);

            if (distanceToPlayer <= closeAttackRange)
            {
                PerformAttack();
                yield break;
            }
            else if (distanceToPlayer > mediumAttackRange)
            {
                ChangeState(BossState.IDLE);
            }
        }
        yield return null;
    }

    IEnumerator FLYATTACK()
    {
        // ���� ���� ���¿����� Fire ���� Ȱ��ȭ
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackInterval;
            Fire.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f); // ���� �� ��� �ð�
            Fire.gameObject.SetActive(false);
            ChangeState(BossState.WALK);
        }
        yield return null;
    }

    IEnumerator CLAWATTACK()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackInterval;
            // �ִϸ��̼� �� ���� ����
            ChangeState(BossState.WALK);
        }
        yield return null;
    }

    IEnumerator BASICATTACK()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackInterval;
            // �⺻ ���� �ִϸ��̼� ����
            ChangeState(BossState.WALK);
        }
        yield return null;
    }

    IEnumerator DEFEND()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackInterval;
            // ��� �ִϸ��̼� ����
            ChangeState(BossState.WALK);
        }
        yield return null;
    }

    IEnumerator DIE()
    {
        animator.Play("Die", 0, 0); // ���� �ִϸ��̼� ����
        Fire.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false); // ������ ���� ����
        UImanger.Instance.HideHpBa();
        UImanger.Instance.EndingpaenlActive();
    }

    void PerformAttack()
    {
        if (distanceToPlayer <= closeAttackRange)
        {
            int randomValue = Random.Range(0, 100);
            if (randomValue < 60) // 60% Ȯ���� Claw Attack
            {
                ChangeState(BossState.CLAWATTACK);
            }
            else // 40% Ȯ���� Basic Attack
            {
                ChangeState(BossState.BASICATTACK);
            }
        }
    }

    void ChangeState(BossState newState)
    {
        state = newState;
    }

    public void BossUpdateHp(float damage)
    {
        Hp -= damage;
        UImanger.Instance.BossSligerBarHp(Hp);

        if (Hp <= 2000)
        {
            ChangeState(BossState.FLYATTACK);
        }
        else
        {
            ChangeState(BossState.DEFEND);
        }
    }

    private void Update()
    {
        if (Target == null) return;

        // ��ǥ�� ��� ����
        nmAgent.SetDestination(Target.position);

        if (Hp <= 0 && state != BossState.DIE)
        {
            ChangeState(BossState.DIE);
        }
    }

    // �浹 ó��
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerManager.instance.PlayerUpdateHp(Ap);
        }
    }
}
