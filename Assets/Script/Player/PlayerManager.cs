using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //플레이어 정보 
    //돈 , Hp, MP, 경험치, 레벨, 능력치(힘, 민첩, 체력), 무기 공격력, 스킬과 능력, 스테미나, 스킬 포인트, 퀘스트, 도전과제




    private void Start()
    {
        PlayerStartData();
    }

    public void PlayerStartData()
    {
        PlayerCoin(100000);

    }


    public void PlayerCoin(int _coin)
    {

        UImanger.Instance.UpdataCoin(_coin);
    
    }

    



}
