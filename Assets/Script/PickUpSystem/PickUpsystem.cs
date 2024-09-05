using Inventory.Model;
using UnityEngine;

public class PickUpsystem : MonoBehaviour
{
    //�ƾ��� ���� 
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
