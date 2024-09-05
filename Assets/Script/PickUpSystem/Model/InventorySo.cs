using System.Collections.Generic;
using System;
using UnityEngine;

namespace Inventory.Model
{
    // �κ��丮 �����͸� �����ϴ� ScriptableObject
    [CreateAssetMenu]
    public class InventorySo : ScriptableObject
    {
        // �κ��丮 ������ �߰�
        [SerializeField]
        private List<InventoryItem> inventoryItems;

        // �κ��丮 ũ��
        [field: SerializeField]
        public int Size { get; private set; } = 10;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

        // �κ��丮�� �ʱ�ȭ�ϴ� �޼ҵ�
        public void Initialize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                // �� ���������� �ʱ�ȭ
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        // InventoryItem�� �߰��ϴ� �޼���
        public void AddItem(InventoryItem item)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = item;
                    InformAboutChange();
                    return; // �������� �߰��� �� �޼��带 ����
                }
            }
        }

        // ItemSo�� �߰��ϴ� �޼���
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
                    return i; // �������� �߰��� �ε����� ��ȯ
                }
            }
            return -1; // �κ��丮�� ���� á�� ��� -1 ��ȯ
        }

        // ���� �κ��丮 ���¸� ��ųʸ� ���·� ��ȯ�ϴ� �޼���
        public Dictionary<int, InventoryItem> GetCurrentInventorystate()
        {
            Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue; // �� �������� ����
                returnValue[i] = inventoryItems[i]; // �κ��丮 ���¸� ��ųʸ��� �߰�
            }

            return returnValue;
        }

        // �ε����� �������� �������� �޼���
        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        // �������� �����ϴ� �޼���
        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItem tempItem = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = tempItem;

            // �κ��丮 ���°� ����Ǿ����� �˸�
            InformAboutChange();
        }

        // �κ��丮 ���� ������Ʈ�� �˸��� �޼���
        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventorystate());
        }

       
    }


    [Serializable]
    public struct InventoryItem
    {
        // ������ ����
        public ItemSo item;

        // �������� ��� �ִ��� ���θ� ��ȯ�ϴ� �Ӽ�
        public bool IsEmpty => item == null;

        // �� InventoryItem�� ��ȯ�ϴ� ���� �޼���
        public static InventoryItem GetEmptyItem() => new InventoryItem
        {
            item = null,
        };
    }
}
