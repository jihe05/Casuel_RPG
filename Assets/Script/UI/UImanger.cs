using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanger : MonoBehaviour
{
    public static UImanger Instance { get; private set; }

    public GameObject ShopPanel;
    public int PlayerCoin =100000;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenAndCloseShop()
    {
        bool isActive = transform.gameObject.activeSelf;

        transform.parent.gameObject.SetActive(!isActive);

    }

    public void Coin(int coin)
    {
       PlayerCoin = coin;
       

    }



}
