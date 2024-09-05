using System.Collections.Generic;
using System;
using UnityEngine;

namespace Inventory.Model
{
    // 인벤토리 데이터를 관리하는 ScriptableObject
    [CreateAssetMenu]
    public class InventorySo : ScriptableObject
    {
        // 인벤토리 데이터 추가
        [SerializeField]
        private List<InventoryItem> inventoryItems;

        // 인벤토리 크기
        [field: SerializeField]
        public int Size { get; private set; } = 10;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

        // 인벤토리를 초기화하는 메소드
        public void Initialize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                // 빈 아이템으로 초기화
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        // InventoryItem을 추가하는 메서드
        public void AddItem(InventoryItem item)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = item;
                    InformAboutChange();
                    return; // 아이템을 추가한 후 메서드를 종료
                }
            }
        }

        // ItemSo를 추가하는 메서드
        public int AddItem(ItemSo item)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = new InventoryItem
                    {
                        item = item,
                    };
                    InformAboutChange();
                    return i; // 아이템이 추가된 인덱스를 반환
                }
            }
            return -1; // 인벤토리가 가득 찼을 경우 -1 반환
        }

        // 현재 인벤토리 상태를 딕셔너리 형태로 반환하는 메서드
        public Dictionary<int, InventoryItem> GetCurrentInventorystate()
        {
            Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue; // 빈 아이템은 제외
                returnValue[i] = inventoryItems[i]; // 인벤토리 상태를 딕셔너리에 추가
            }

            return returnValue;
        }

        // 인덱스로 아이템을 가져오는 메서드
        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        // 아이템을 스왑하는 메서드
        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItem tempItem = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = tempItem;

            // 인벤토리 상태가 변경되었음을 알림
            InformAboutChange();
        }

        // 인벤토리 상태 업데이트를 알리는 메서드
        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventorystate());
        }

       
    }


    [Serializable]
    public struct InventoryItem
    {
        // 아이템 정보
        public ItemSo item;

        // 아이템이 비어 있는지 여부를 반환하는 속성
        public bool IsEmpty => item == null;

        // 빈 InventoryItem을 반환하는 정적 메서드
        public static InventoryItem GetEmptyItem() => new InventoryItem
        {
            item = null,
        };
    }
}
