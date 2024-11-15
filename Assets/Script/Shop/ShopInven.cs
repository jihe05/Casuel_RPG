using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopInven : MonoBehaviour
{
    [SerializeField]
    private ShopItem ShopItem_Prefab;

    [SerializeField]
    private RectTransform ContentPanel;

    //인벤토리 UI항목 리스트
    private List<ShopItem> _listOfUIItme = new List<ShopItem>();

    //이벤트(설명 요청시)
    public event Action<int> OnStartEnter;



    //프리팹 생성
    public void InitShopUI()
    {
        for (int i = 0; i < 21; i++)
        {
            ShopItem shopItem = Instantiate(ShopItem_Prefab, Vector3.zero, Quaternion.identity);

            //생성될 위치 
            shopItem.transform.SetParent(ContentPanel);

            _listOfUIItme.Add(shopItem);

            //아이템 선택처리
            shopItem.OnItemClicked += HandleItemSlelction;

        }

    }


    public void UpdateData(KeyValuePair<int, ShopInvenItem> shopItem)
    {
        if (_listOfUIItme.Count > shopItem.Key)
        {
            // 아이템의 가격과 이미지 업데이트
            _listOfUIItme[shopItem.Key].SetItemData(shopItem.Value.shopItem, shopItem.Value.coin);
        }
    }



    public void HandleItemSlelction(ShopItem shopItemUI)
    {
        int index = _listOfUIItme.IndexOf(shopItemUI);

        OnStartEnter?.Invoke(index);
    }



    //활성화 될을때
    public void Show()
    {
        gameObject.SetActive(true);
    }

}
