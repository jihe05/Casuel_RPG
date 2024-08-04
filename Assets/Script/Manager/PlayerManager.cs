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

    public float Player_Hp = 10000;
    public float Player_Hg = 20;
    public float Player_Stamina = 30;

    public int Player_Level = 1;


    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {

    }

    public void PlayerUpdateHp(float Ap)
    {
        Player_Hp -= Ap;
        PlayerPrefs.SetFloat("Player_Hp", Player_Hp);
        UImanger.Instance.PlayerSliderbarHp(Ap);
    }

    public void PlayerMonsterTrgger()
    {
        monstermove.MonsterUpdateHp(Player_Hg);
    }

    public void PlayerBossTrgger()
    {
        Bossmove = FindObjectOfType<Bossmove>();
        Bossmove.BossUpdateHp(Player_Hg);
    }

    public void PlayerLevelUpUpdate()
    {
        Player_Level++;
        UImanger.Instance.PlayerlevelUp(Player_Level);
        move.playerLevelUp();
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
        UImanger.Instance.PlayerSliderbarHp(int.Parse(currentItemHp));
    }

    public void UseHg(string currentItemHg)
    {
        Player_Hg += int.Parse(currentItemHg);
        Debug.Log("Player_Hg: " + Player_Hg);
        UImanger.Instance.PlayerSliderbarHg(int.Parse(currentItemHg));
    }

    public void UseStamina(string currentItemStamina)
    {
        Player_Stamina += int.Parse(currentItemStamina);
        UImanger.Instance.PlayerSliderbarStamina(int.Parse(currentItemStamina));
    }
}
