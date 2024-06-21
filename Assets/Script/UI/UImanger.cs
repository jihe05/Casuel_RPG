using Ivnentory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanger : MonoBehaviour
{
    public static UImanger Instance { get; private set; }
   

    public Text Text_playercoin;

    private void Awake()
    {
        Instance = this;
        
    }

    public void UpdataCoin(int coin)
    {
     
       Text_playercoin.text = coin.ToString("N0");


    }



}
