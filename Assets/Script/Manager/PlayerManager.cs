using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public GameObject player;

    public Monstermove monstermove;
    Bossmove Bossmove;

    public float Player_Hp = 10000;
    public float Player_Ap = 20;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(transform.parent.gameObject);
    }

    private void Start()
    {
      
    }

    public void PlayerUpdateHp(float Ap)
    {
        Player_Hp -= Ap;
        PlayerPrefs.SetFloat("Player_Hp", Player_Hp);
        UImanger.Instance.PlayerSliderbar(Ap);
    }

    public void PlayerMonsterTrgger()
    {
        monstermove.MonsterUpdateHp(Player_Ap);
    }
    public void PlayerBossTrgger()
    {
      
        Bossmove = FindObjectOfType<Bossmove>();
        Bossmove.UpdateHp(Player_Ap);
    }


}
