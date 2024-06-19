using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //�κ��丮�� �ʱ�ȭ�ϴ� �޼ҵ�
    public void Initialize()
    { 
       inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            //�� ���������� �ʱ�ȭ 
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    
    }

    //�������� �߰��ϴ� �޼���
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
