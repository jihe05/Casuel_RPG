using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�÷��̾� ���� 
    //�� , Hp, MP, ����ġ, ����, �ɷ�ġ(��, ��ø, ü��), ���� ���ݷ�, ��ų�� �ɷ�, ���׹̳�, ��ų ����Ʈ, ����Ʈ, ��������




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
