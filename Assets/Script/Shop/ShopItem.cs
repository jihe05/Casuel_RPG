using Inventory.Model;
using Inventory.UI;
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
    private ShopSo shopSo; // ShopSo 인스턴스 참조

    // 수량은 1개
    [field: SerializeField]
    public int Quantity { get; set; } = 1;

    // 클릭, 드랍 이벤트
    public event Action<ShopItem> OnItemClicked, InItemDroppedOn;

    private void Start()
    {
        // 크기 초기화
        gameObject.transform.localScale = Vector3.one;
    }

    public void SetItemData(Sprite sprite, int itePrice)
    {
        Itemimage.sprite = sprite;
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
        Sprite sprite = Itemimage.sprite;
        Debug.Log(shopSo.GetItemBySprite(sprite));


        // 해당 이미지를 가진 아이템을 가져오기
        ItemSo item = shopSo.GetItemBySprite(sprite);

        
        if (item != null)
        {
            UImanger.Instance.BayCoinAndImage(coin, sprite);
        }
        else
        {
            Debug.LogError("아이템을 찾을 수 없습니다.");
        }
    }
}
