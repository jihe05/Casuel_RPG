using Inventory.Model;
using Ivnentory;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image Itemimage; // 아이템 이미지

    [SerializeField]
    private Text ItemPrice; // 아이템 가격

    [SerializeField]
    private GameObject DataPanel;

    public InventorySo inventorySo;

    public ItemSo inventoryItem { get; private set; }

    public InventoryController InventoryController { get; set; }

    // 클릭, 드랍 이벤트
    public event Action<ShopItem> OnItemClicked, InItemDroppedOn;

    private void Start()
    {
        // 크기 초기화
        gameObject.transform.localScale = Vector3.one;
        InventoryController = FindObjectOfType<InventoryController>();
    }

    public void SetItemData(ItemSo itemSo, int itePrice)
    {
        inventoryItem = itemSo;
        Itemimage.sprite = itemSo.ItemImage;
        ItemPrice.text = itePrice.ToString("N0");
    }

    // 클릭 이벤트 처리
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
            Debug.Log("널.");

       
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
