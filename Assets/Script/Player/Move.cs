using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float gravity = -23f;
    private int count = 0;

    private float verticalVelocity;//�����ӵ�

    public CharacterController characterController;

    public Animator animator_Player;

    Monstermove monstermove;

    private IPlayerState currentState;

    public ParticleSystem particle;

    [HideInInspector]  public Rigidbody Rgb;

    public AudioSource soldSound;

    public AudioSource MoveSound;

    public AudioClip[] MoveClips;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        characterController = GetComponent<CharacterController>();
        monstermove = GetComponent<Monstermove>();
        Rgb= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Rgb.useGravity = true;
        ChangeState(new IdleState(this));
    }

    private void Update()
    {
        currentState?.ExecuteOnUpdate();

        // ���콺 Ŭ�� �� ���� ���·� ��ȯ
        if (Input.GetMouseButtonDown(0) && !(currentState is AtKState))
        {
            soldSound.Play();
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
            animator_Player.SetBool("Jump", false);
        }
        else
        {

            verticalVelocity += gravity * Time.deltaTime;
        }


        move.y = verticalVelocity;
        characterController.Move(move * Time.deltaTime);
    }

    public void OnAnimatorPlayer(GameObject player)
    {
        animator_Player = player.GetComponent<Animator>();

    }


    public void playerLevelUp()
    {
        Debug.Log("playerLevelUp");
        ChangeState(new LevelUP(this));

        Invoke("LevelUpEnd", 2f);

    }

    public void LevelUpEnd()
    {
        Debug.Log("IdleState");
        gravity = -23;
        ChangeState(new IdleState(this));

    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collision.collider.CompareTag("Monster"))
            {
                PlayerManager.instance.PlayerMonsterTrgger();
            }
            if (collision.collider.CompareTag("Boss"))
            {
                Debug.Log("���� ������ : OnCollisionStay");
                PlayerManager.instance.PlayerBossTrgger();
            }

        }

        if (collision.collider.CompareTag("EventCollider"))
        {
            UImanger.Instance.EventGuidCollider();


        }

    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("BosEvent"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log(transform.position);
            characterController.enabled = false;
            SceneManager.LoadScene("Bosmap");
        }
        if (other.CompareTag("Boss") && Input.GetMouseButtonDown(0))
        {
                Debug.Log("���� ������ : OnTriggerEnter");
                PlayerManager.instance.PlayerBossTrgger();
        }
        if (other.CompareTag("Guide"))
        {
          
            EventManager.Instans.TalkePanelActive();
            EventManager.Instans.ColiderFalse();

        }
        if (other.CompareTag("Princess"))
        {
            EventManager.Instans.Princes();

        }
        if (other.CompareTag("King"))
        {
            EventManager.Instans.TalkePanelDestroy();
        }
        if (other.CompareTag("BosAttack"))
        {
            Bossmove.Instance.PerformAttack();
        }
       
        if (other.CompareTag("EnventBox"))
        {

            UImanger.Instance.EventButton();
        }

        if (other.CompareTag("Ball"))
        {
            DataManager.Instance.CompleteMission(9);
        }

        if (other.CompareTag("Timeline"))
        {
            EventManager.Instans.BosClider();
        }
        else
        {
            return;
        }


    }

    // ���� �ε�� �� ȣ��
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Bosmap")
        {
            // ���⼭ ���� ������ �ε�� �� ������Ʈ�� ��ġ�� ȸ���� ����
            Invoke("SetPlayerPositionAndRotation", 0.01f);
            SceneManager.sceneLoaded -= OnSceneLoaded; // �̺�Ʈ �ڵ鷯 ����
            BGM.instance.BosMapBGM();
        }
    }

    private void SetPlayerPositionAndRotation()
    {
        transform.position = new Vector3(38f, -12f, 144.5f);
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        characterController.enabled = true;


    }

}
