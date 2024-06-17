using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanger : MonoBehaviour
{
    public static UImanger Instance { get; private set; }

    public GameObject ShopPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenAndCloseShop()
    {
        bool isActive = ShopPanel.activeSelf;

        ShopPanel.SetActive(!isActive);
    }



}
