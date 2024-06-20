using Inventory.Model;
using Ivnentory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ivnentory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private UIinventory InventoryUI;

        [SerializeField]
        private InventorySo InventoryData;

        public List<InventoryItem> InventoryItems = new List<InventoryItem>();

               
        private void Start()
        {
            PrepareUI();
            PrepareInventorydata();
        }

        //�κ��丮 ������ �غ�
        private void PrepareInventorydata()
        {
            //�κ��丮 �ʱ�ȭ �Լ� ȣ��
            InventoryData.Initialize();
            //�κ��丮 ������Ʈ �̺�Ʈ�� UpdateInventoryUI �޼��� ��� 
            InventoryData.OnInventoryUpdated += UpdateInventoryUI;

            foreach (InventoryItem item in InventoryItems)
            {
                if (item.IsEmpty)
                    continue;
                //������ �߰� �޼��� ȣ��
                InventoryData.AddItem(item);
            }
            
        }

        //�κ��丮 UI�� ���� �κ��丮 ���·� ��������Ʈ�ϴ� �޼��� 
        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoruState)
        {
            //��� �κ��丮 �ʱ�ȭ 
           InventoryUI.ResetAllItem();
            //�̺��丮 ���¸� �ݺ��Ͽ� �� �Ɵ�� �����͸� UI�� ������Ʈ
            foreach (var item in inventoruState)
            {
                InventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);   
            }
        }

        //UI�� �غ��ϰ� �̺�Ʈ �ڵ鷯 �����ϴ� �޼���
        private void PrepareUI()
        {
            
            InventoryUI.InitalizeInventoryUI(InventoryData.Size);//ũ�� �ʱ�ȭ 

            //�̺�Ʈ �ڵ鷯 ����(���� ��û ó�� / ������ ��ü ó�� / �巡�� ó�� / ������ �۾� ��û)
            InventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            InventoryUI.OnSwapItems += HandleSwapItems;
            InventoryUI.OnStartDragging += HandleDragging;
            InventoryUI.OnItemactionRequsted += HandleItemActionRequset;
        }


        //������ �۾� ǥ�� 
        private void HandleItemActionRequset(int itemIndex)
        {

        }

        //�巡�� ó�� 
        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = InventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;

            //�巡�� ������ �̹��� ����
            InventoryUI.CreateDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity);
        }

        //������ ��ü ó�� 
        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryData.SwapItems(itemIndex_1, itemIndex_2);
        }

        //���� ��û ó�� 
        private void HandleDescriptionRequest(int itemIndex)
        {
            
            InventoryItem inventoryItme = InventoryData.GetItemAt(itemIndex);
            if (inventoryItme.IsEmpty)
            {

                InventoryUI.ResetSelection();
                return;

            }

            ItemSo item = inventoryItme.item;
            InventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.name, item.Description);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (InventoryUI.isActiveAndEnabled == false)
                {
                    //Ȱ��ȭ
                    InventoryUI.Show();

                    //���� �κ��丮 ���¸� ��ųʸ� ���·� ��ȯ�ϴ� �޼��� ȣ��
                    foreach (var item in InventoryData.GetCurrentInventorystate())
                    {
                        //�̺��丮 UI�� ������ ������Ʈ(�κ������� �ε���, �κ� ������ �̹���, �κ� ������ ����)
                        InventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                    }

                }
                else
                {
                    //��Ȱ��ȭ
                    InventoryUI.Hide();
                }

            }
        }

    }
}