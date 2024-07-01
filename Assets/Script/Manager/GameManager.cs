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
        //ㅓ버튼 클릭 (상태 , 애니메이션) 호출
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
        //카메라를 보며 
        LookAtCamera();
        //이동 메서드 호출 취소 메서드 호출
        mainSlime.GetComponent<EnemyAi>().CancelGoNextDestination();

        //상태를 Idel로 변경
        ChangeStateTo(SlimeAnimationState.Idle);
    }

    //슬라임의 상태 변경
    public void ChangeStateTo(SlimeAnimationState state)
    {
        
       if (mainSlime == null) return;    

       //같은 상태라면 반환
       if (state == mainSlime.GetComponent<EnemyAi>().currentState) return;

        //슬라임의 상태를 새로은 상태로 변경
        mainSlime.GetComponent<EnemyAi>().currentState = state ;
    }

    //카메라를 바라보는 함수
    void LookAtCamera()
    {
        //카메라쪽으로 회전 시키고 , Y축 회전을 카메라의Y출 회전과 동일하게 
       mainSlime.transform.rotation = Quaternion.Euler(new Vector3(mainSlime.transform.rotation.x, cam.transform.rotation.y, mainSlime.transform.rotation.z));   
    }
}
