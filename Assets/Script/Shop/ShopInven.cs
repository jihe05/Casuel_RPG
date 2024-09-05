using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopInven : MonoBehaviour
{
    [SerializeField]
    private ShopItem ShopItem_Prefab;

    [SerializeField]
    private RectTransform ContentPanel;

    //�κ��丮 UI�׸� ����Ʈ
    private List<ShopItem> _listOfUIItme = new List<ShopItem>();

    //�̺�Ʈ(���� ��û��)
    public event Action<int> OnStartEnter;



    //������ ����
    public void InitShopUI()
    {
        for (int i = 0; i < 21; i++)
        {
            ShopItem shopItem = Instantiate(ShopItem_Prefab, Vector3.zero, Quaternion.identity);

            //������ ��ġ 
            shopItem.transform.SetParent(ContentPanel);

            _listOfUIItme.Add(shopItem);

            //������ ����ó��
            shopItem.OnItemClicked += HandleItemSlelction;

        }

    }


    public void UpdateData(KeyValuePair<int, ShopInvenItem> shopItem)
    {
        if (_listOfUIItme.Count > shopItem.Key)
        {
            // �������� ���ݰ� �̹��� ������Ʈ
            _listOfUIItme[shopItem.Key].SetItemData(shopItem.Value.shopItem, shopItem.Value.coin);
        }
    }



    public void HandleItemSlelction(ShopItem shopItemUI)
    {
        int index = _listOfUIItme.IndexOf(shopItemUI);

        OnStartEnter?.Invoke(index);
    }



    //Ȱ��ȭ ������
    public void Show()
    {
        gameObject.SetActive(true);
    }

}
