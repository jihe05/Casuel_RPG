using Inventory.Model;
using Ivnentory;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UImanger : MonoBehaviour
{
    public static UImanger Instance { get; private set; }

    [SerializeField]
    private InventorySo inventoryData;

    public Text Text_playercoin;

    public int Coin = 10000;

    private void Awake()
    {
        Instance = this;
        StartCoin();
    }

    public void StartCoin()
    {
        Text_playercoin.text = Coin.ToString("N0");

    }

    public void UpdataCoinAndImage(int _coin , Sprite itemImage)
    {
        if (_coin < Coin  && Coin != 0)
        {
            Coin -= _coin;
            _coin = Coin;
            Text_playercoin.text = _coin.ToString("N0");

            Debug.Log("1");
            InventoryUpdate(itemImage);
            Debug.Log("5");

        }
        else
        {
            return;

        }
      

    }

    private void InventoryUpdate(Sprite itemImage)
    {
        Debug.Log("2");
        Item item = itemImage.GetComponent<Item>();
        Debug.Log("3");

        if (item != null)
        {
            Debug.Log("4");
            int reminder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
            Debug.Log("reminder : " + reminder);
            item.Quantity = reminder;

        }
        else
        {
            Debug.Log("null");
        }
    }
}
