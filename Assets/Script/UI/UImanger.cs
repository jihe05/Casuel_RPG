using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanger : MonoBehaviour
{
    public static UImanger Instance { get; private set; }

    public GameObject ShopPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenAndCloseShop()
    {
        bool isActive = transform.gameObject.activeSelf;

        transform.parent.gameObject.SetActive(!isActive);

    }



}
