using Inventory.Model;
using UnityEngine;

public class PickUpsystem : MonoBehaviour
{
    //아아템 정보 
    [field: SerializeField]
    public ItemSo InventoryItem { get; private set; }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage;
    }

    internal void DestroyItem()
    {
        GetComponent<Collider>().enabled = false;

        Destroy(gameObject);

    }




}
