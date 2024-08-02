using Inventory.Model;
using UnityEngine;

public class PickUpsystem : MonoBehaviour
{
    //아아템 정보 
    [field: SerializeField]
    public ItemSo InventoryItem { get; private set; }

    //개수는 1개
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
        //받아온 아이템의 ItemSO의 전보를 가져옴
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
