using Inventory.Model;
using Ivnentory;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image Itemimage; // ������ �̹���

    [SerializeField]
    private Text ItemPrice; // ������ ����

    [SerializeField]
    private GameObject DataPanel;

    public InventorySo inventorySo;

    public ItemSo inventoryItem { get; private set; }

    public InventoryController InventoryController { get; set; }

    // Ŭ��, ��� �̺�Ʈ
    public event Action<ShopItem> OnItemClicked, InItemDroppedOn;

    private void Start()
    {
        // ũ�� �ʱ�ȭ
        gameObject.transform.localScale = Vector3.one;
        InventoryController = FindObjectOfType<InventoryController>();
    }

    public void SetItemData(ItemSo itemSo, int itePrice)
    {
        inventoryItem = itemSo;
        Itemimage.sprite = itemSo.ItemImage;
        ItemPrice.text = itePrice.ToString("N0");
    }

    // Ŭ�� �̺�Ʈ ó��
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnItemClicked?.Invoke(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        InItemDroppedOn.Invoke(this);
    }


    public void ItemPriceButtonClick()
    {
        int coin = int.Parse(ItemPrice.text);

        UImanger.Instance.BayCoinAndImage(coin);


        if (InventoryController != null)
        {
            InventoryController.AddItemInventory(inventoryItem);

        }
        else
            Debug.Log("��.");

       
    }
   
    public void Test_OnMouseEnter()
    {
        DataPanel.SetActive(true);
        UIShopDescription.instance.SetShopEfficacy(inventoryItem.Name, inventoryItem.ItemHp, inventoryItem.ItemHg);
    }
    public void Test_OnMouseExit()
    {
        DataPanel.SetActive(false);
    }

}
