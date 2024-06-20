using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsystem : MonoBehaviour
{
    [SerializeField]
    private InventorySo inventoryData;

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponentInParent<Item>();
        if (item != null)
        {
            
            int reminder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
            Debug.Log("reminder" + reminder);
            if (reminder == 0)
            {
                Debug.Log("00");
                item.DestroyItem();
            }
            else
            {
                Debug.Log("¤©¤©");
                item.Quantity = reminder;
            }

        }
        else 
        {
            Debug.Log("null");
        }
    }




}
