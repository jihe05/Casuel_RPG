using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainSlime;
    public Button idleBut, walkBut,jumpBut,attackBut,damageBut0,damageBut1,damageBut2;
    public Camera cam;
    private void Start()
    {
        //�ù�ư Ŭ�� (���� , �ִϸ��̼�) ȣ��
        idleBut.onClick.AddListener( delegate { Idle(); } );
        walkBut.onClick.AddListener(delegate {  ChangeStateTo(SlimeAnimationState.Walk); });
        jumpBut.onClick.AddListener(delegate { LookAtCamera(); ChangeStateTo(SlimeAnimationState.Jump); });
        attackBut.onClick.AddListener(delegate { LookAtCamera(); ChangeStateTo(SlimeAnimationState.Attack); });
        damageBut0.onClick.AddListener(delegate { LookAtCamera(); ChangeStateTo(SlimeAnimationState.Damage); mainSlime.GetComponent<EnemyAi>().damType = 0; });
        damageBut1.onClick.AddListener(delegate { LookAtCamera(); ChangeStateTo(SlimeAnimationState.Damage); mainSlime.GetComponent<EnemyAi>().damType = 1; });
        damageBut2.onClick.AddListener(delegate { LookAtCamera(); ChangeStateTo(SlimeAnimationState.Damage); mainSlime.GetComponent<EnemyAi>().damType = 2; });
    }

    //Idle
    void Idle()
    {
        //ī�޶� ���� 
        LookAtCamera();
        //�̵� �޼��� ȣ�� ��� �޼��� ȣ��
        mainSlime.GetComponent<EnemyAi>().CancelGoNextDestination();

        //���¸� Idel�� ����
        ChangeStateTo(SlimeAnimationState.Idle);
    }

    //�������� ���� ����
    public void ChangeStateTo(SlimeAnimationState state)
    {
        
       if (mainSlime == null) return;    

       //���� ���¶�� ��ȯ
       if (state == mainSlime.GetComponent<EnemyAi>().currentState) return;

        //�������� ���¸� ������ ���·� ����
        mainSlime.GetComponent<EnemyAi>().currentState = state ;
    }

    //ī�޶� �ٶ󺸴� �Լ�
    void LookAtCamera()
    {
        //ī�޶������� ȸ�� ��Ű�� , Y�� ȸ���� ī�޶���Y�� ȸ���� �����ϰ� 
       mainSlime.transform.rotation = Quaternion.Euler(new Vector3(mainSlime.transform.rotation.x, cam.transform.rotation.y, mainSlime.transform.rotation.z));   
    }
}
