 using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Model
{
    //�κ��丮 �����͸� �����ϴ� ScriptableObject
    [CreateAssetMenu]
    public class InventorySo : ScriptableObject
    {
        //�κ��丮 ������ �߰�
        [SerializeField]
        private List<InventoryItem> inventoryItems;

        //�κ��丮 ũ���� ��Ÿ���� �Ӽ�, �⺻�� 10
        [field: SerializeField]
        public int Size { get; private set; } = 10;

       // private const int MaxSize = 50;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;


        //�κ��丮�� �ʱ�ȭ�ϴ� �޼ҵ�m  
        public void Initialize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                //�� ���������� �ʱ�ȭ 
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }

        }

        public void AddItem(InventoryItem item)
        {
            //�������� �̸��� ������ �޾ƿ� �޼��� ȣ��
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


        //���� �κ��丮 ���¸� ��ųʸ� ���·� ��ȯ�ϴ� �޼���
        public Dictionary<int, InventoryItem> GetCurrentInventorystate()
        {
            Dictionary<int, InventoryItem> returnValue =
                  new Dictionary<int, InventoryItem>();

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;//�� �������� �����մϴ�.
                returnValue[i] = inventoryItems[i];//�κ��丮 ���¸� ��ųʸ��� �߰��մϴ�.

            }
            return returnValue;

        }

        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        //�̵����̹��� ����
        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItem item = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = item;
            //���� �������� ��ųʸ� ���·� ��ȯ 
            InformAboutChange();
        }

        private void InformAboutChange()
        {
            //��ųʸ� ���·� ��ȯ
            OnInventoryUpdated?.Invoke(GetCurrentInventorystate());
        }
    }

    [Serializable]
    public struct InventoryItem //����ü 
    {
        //������ ����
        public int quantity;
        //������ ����  
        public ItemSo item;

        //������ ��� �ִ��� ���θ� ��ȯ�ϴ� �б� ���� �Ӽ�
        public bool IsEmpty => item == null;

        //������ ������ �����Ͽ� ���ο� InventoryItem�� ��ȯ�ϴ� �޼���
        public InventoryItem ChangeQyantity(int newQuantity)
        {
            return new InventoryItem
            {
                item = this.item,
                quantity = newQuantity,

            };

        }

        //�� InventoryItem�� ��ȯ�ϴ� ���� �޼���
        public static InventoryItem GetEmptyItem() => new InventoryItem
        {
            item = null,
            quantity = 0,
        };

    }



}
