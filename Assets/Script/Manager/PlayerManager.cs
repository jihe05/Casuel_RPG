using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Move move;

    public GameObject player;

    public Text PlayerName;

    public Monstermove monstermove;
    Bossmove Bossmove;

    public float Player_Hp;
    public float Player_Ap;
    public float Player_Hg;

    public int Player_Level;


    private void Awake()
    {
        Debug.Log("playerHp :" + Player_Hp);
        instance = this;

    }

    private void Start()
    {
         Player_Hp = 10000;
        Player_Ap = 500;
         Player_Hg = 20;
        Player_Level = 1;
    }

    private void Update()
    {
        if (Player_Level == 9)
        {
            EventManager.Instans.PotalOpen();
        }
    }

    public void PlayerUpdateHp(float Ap)
    {
        //Hp가 0보다 작으면 죽음
        if (Player_Hp <= 0)
        {
            Debug.Log("죽음");
        }
        else
        {
            Player_Hp -= Ap;
            UImanger.Instance.PlayerSliderbarHp(Player_Hp);

        }
       
    }

    public void PlayerMonsterTrgger()
    {
        monstermove.MonsterUpdateHp(Player_Ap);
    }

    public void PlayerBossTrgger()
    {
        Bossmove = FindObjectOfType<Bossmove>();
        Bossmove.BossUpdateHp(Player_Ap);
    }

    public void PlayerLevelUpUpdate()
    {
        Player_Level++;
        move.playerLevelUp();

        Invoke("LeveUpUI", 2);
        
    }
    public void LeveUpUI()
    {
        Debug.Log("레벨업");
        UImanger.Instance.PlayerlevelUp(Player_Level);

    }

    public void ActiveFalseMove()
    {
        move.enabled = false;

    }

    public void ActiveTrueMove()
    {
        move.enabled = true;

    }

    public void UseHp(string currentItemHp)
    {
        Player_Hp += int.Parse(currentItemHp);
        Debug.Log(Player_Hp);
        UImanger.Instance.PlayerSliderbarAddHp(int.Parse(currentItemHp));
    }


    public void UseHg(string currentItemHg)
    {
        Player_Hg += int.Parse(currentItemHg);
        UImanger.Instance.PlayerSliderbarHg(int.Parse(currentItemHg));
    }

}
