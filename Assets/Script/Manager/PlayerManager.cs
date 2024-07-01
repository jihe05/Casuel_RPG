using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public GameObject player;

   public Monstermove monstermove;

    public float Player_Hp = 10000;
    public float Player_Ap = 20;

    private void Awake()
    {
        instance = this;
    }

    public void PlayerUpdateHp(float Ap)
    {
        Player_Hp -= Ap;

        UImanger.Instance.PlayerSliderbar(Ap);
    }

    public void PlayerTrgger()
    {
        monstermove.MonsterUpdateHp(Player_Ap);
    }
    
}
