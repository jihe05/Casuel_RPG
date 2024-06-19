using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인벤토리 데이터를 관리하는 ScriptableObject
[CreateAssetMenu]
public class InventorySo : ScriptableObject
{
    //인벤토리 데이터 추가
    [SerializeField]
    private List<InventoryItem> inventoryItems;

    //인벤토리 크리를 나타내는 속성, 기본값 10
    [field: SerializeField]
    public int Size { get; private set; } = 10;

    //인벤토리를 초기화하는 메소드
    public void Initialize()
    { 
       inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            //빈 아이템으로 초기화 
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    
    }

    //아이템을 추가하는 메서드
    public void AddItem(ItemSo item, int quantity)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                inventoryItems[i] = new InventoryItem
                {
                    item = item,
                    quantity = quantity
                };
                return;
            }
        }
    }

    //현재 인벤토리 상태를 딕셔너리 현태로 반환하는 메서드
    public Dictionary<int, InventoryItem> GetCurrentInventorystate()
    {
        Dictionary<int, InventoryItem> returnValue =
              new Dictionary<int, InventoryItem>();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
                continue;//빈 아이템은 제외합니다.
            returnValue[i] = inventoryItems[i];//인벤토리 상태를 딕셔너리에 추가합니다.

        }
        return returnValue;
    
    }

}

[Serializable]
public struct InventoryItem //구조체 
{
    //아이템 수량
    public int quantity;
    //아이템 정보
    public ItemSo item;

    //아이템 비어 있는지 여부를 반환하는 읽기 전용 속성
    public bool IsEmpty => item == null;

    //아이템 수량을 변경하여 새로운 InventoryItem을 반환하는 메서드
    public InventoryItem ChangeQyantity(int newQuantity)
    {
        return new InventoryItem
        {
            item = this.item,
            quantity = newQuantity,

        };
    
    }

    //빈 InventoryItem을 반환하는 전적 메서드
    public static InventoryItem GetEmptyItem() => new InventoryItem
    {
         item = null,
         quantity = 0,
    };

}
