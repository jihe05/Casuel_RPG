using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsystem : MonoBehaviour
{
    //�ƾ��� ���� 
    [field: SerializeField]
    public ItemSo InventoryItem { get; private set; }

    //������ 1��
    [field: SerializeField]
    public int Quantity { get; set; } = 1;


    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage;
    }

    internal void DestroyItem()
    {
        GetComponent<Collider>().enabled = false;

        Destroy(gameObject);

    }


    [SerializeField]
    private InventorySo inventoryData;

    private void OnTriggerEnter(Collider collision)
    {
        //�޾ƿ� �������� ItemSO�� ������ ������
        Item item = collision.GetComponent<Item>();

        if (item != null)
        {

            int reminder = inventoryData.AddItem(InventoryItem, Quantity);
            if (reminder == 0)
                DestroyItem();

            else
                Quantity = reminder;

        }



    }




}
