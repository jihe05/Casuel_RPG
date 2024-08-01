 using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Model
{
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

       // private const int MaxSize = 50;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;


        //인벤토리를 초기화하는 메소드m  
        public void Initialize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                //빈 아이템으로 초기화 
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }

        }

        public void AddItem(InventoryItem item)
        {
            //아이템의 이름과 설명을 받아와 메서드 호출
            AddItem(item.item, item.quantity);
        }


        public int AddItem(ItemSo item, int quantity)
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
                    InformAboutChange();
                    return 0;
                }
            }

            //if (Size < MaxSize)
            //{
            //    ExpandInventory(Math.Min(Size + 10, MaxSize));
            //    return AddItem(item, quantity);
            //}

            return quantity;
        }

        //private void ExpandInventory(int newSize)
        //{
        //    if (newSize > Size)
        //    {
        //        Size = newSize;
        //        for (int i = inventoryItems.Count; i < Size; i++)
        //        {
        //            inventoryItems.Add(InventoryItem.GetEmptyItem());
        //        }
        //        InformAboutChange();
        //    }
        //}


        //현재 인벤토리 상태를 딕셔너리 형태로 반환하는 메서드
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

        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        //이동시이미지 변경
        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItem item = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = item;
            //받은 아이템을 딕셔너리 현태로 변환 
            InformAboutChange();
        }

        private void InformAboutChange()
        {
            //딕셔너리 형태로 변환
            OnInventoryUpdated?.Invoke(GetCurrentInventorystate());
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



}
