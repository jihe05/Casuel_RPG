using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInven : MonoBehaviour
{
    [SerializeField]
    private ShopItem ShopItem_Prefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private UIInventoryDescription itemUIDescription;

    //인벤토리 UI항목 리스트
     private List<ShopItem> _listOfUIItme = new List<ShopItem>();

    //이벤트(설명 요청시)
    public event Action<int> OnDescriptionRequested;


    private void OnEnable()
    {
        




    }

    //프리팹 생성
    public void InitShopUI()
    {
        for (int i = 0; i < 8; i++)
        {
            ShopItem shopItem = Instantiate(ShopItem_Prefab, Vector3.zero, Quaternion.identity);

            //생성될 위치 
            shopItem.transform.SetParent(contentPanel);

            Debug.Log("설정");
            _listOfUIItme.Add(shopItem);

            //아이템 선택처리
            shopItem.OnItemClicked += HandleItemSlelction;

        }
    
    }


    public void UpdateData(int itemIndex, Sprite itemImage, int itemCoin)
    {
        if (_listOfUIItme.Count > itemIndex)
        {
            _listOfUIItme[itemIndex].SetItemData(itemImage, itemCoin);
        }
    }


    private void HandleItemSlelction(ShopItem shopItemUI)
    {
        int index = _listOfUIItme.IndexOf(shopItemUI);

        OnDescriptionRequested?.Invoke(index);
    }


    //활성화 될을때
    public void Show()
    {
        gameObject.SetActive(true);
        //ResetSelection();
    }


    //비활성화 상태
    public void Hide()
    {
        gameObject.SetActive(false);
        //ResetDraggedItem();//드래그 종료 메서드
    }

}
