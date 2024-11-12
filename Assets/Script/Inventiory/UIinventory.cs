using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Ivnentory.UI
{
    public class UIinventory : MonoBehaviour
    {

        //�κ� ������ ��һ���
        [SerializeField]
        private UIinventoryItem itmePrefab;

        //��ġ�� �г�
        [SerializeField]
        private RectTransform contentPanel;

        //������ ���� UI
        [SerializeField]
        private UIInventoryDescription itemUIDescription;


        //���콺 ������
        [SerializeField]
        private ItemMousFolloer MousFolloer;

        private string currentItemHp;
        private string currentItemHg;

        //�κ��丮 UI�׸� ����Ʈ
        List<UIinventoryItem> _listOfUIItme = new List<UIinventoryItem>();

        //�̺�Ʈ (���� ��û�� , ������ �۾� ��û��, �巡�� ���۽�, )
        public event Action<int>
            OnDescriptionRequested, OnItemactionRequsted, OnStartDragging;

        //�̺�Ʈ (������ ��ü��)
        public event Action<int, int> OnSwapItems;

        //currentlyDraggedItemIndex : ���� �巡�� ���� ������ �ε���
        private int currentlyDraggedItemIndex = -1;

        int ItemIndex;

        private void Start()
        {
            gameObject.SetActive(false);

            Hide();
        }
        private void Awake()
        {
            MousFolloer.Toggle(false);
            itemUIDescription.ResetDescription();
        }

        //UI Size�ʱ�ȭ 
        public void InitalizeInventoryUI(int inventorysize)
        {
            //�κ��丮�� ũ�� ��ŭ �ݺ�
            for (int i = 0; i < inventorysize; i++)
            {
                //inventoryItemUI�� ���� ��������
                UIinventoryItem uiItme = Instantiate(itmePrefab, Vector3.zero, Quaternion.identity);

                //������ ��ġ
                uiItme.transform.SetParent(contentPanel);

                //�߰�
                _listOfUIItme.Add(uiItme);
                //������ ���� ó�� / �巡�� ���� ó�� / ��ü ó�� / ������ �۾� ǥ�� ó��
                uiItme.OnItemClicked += HandleItemSelection;
                uiItme.OnItemBegingDrag += HandleBeginDrag;
                uiItme.OnItemDroppedOn += HandleSwap;
                uiItme.OnItemEndDrag += HandleEndDrag;
                uiItme.OnRightMouseBtnClick += HendleshowItemActions;

            }

        }

        //������ �ʱ�ȭ 
        internal void ResetAllItem()
        {
            Debug.Log("item");
            //��� �������� 
            foreach (var item in _listOfUIItme)
            {
                item.ResetData();//������ �ʱ�ȭ
               
                item.Deselect();//�׵θ� ��Ȱ��ȭ 
            }
        }

        //������ ���� ������Ʈ
        public void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description, string itemHp, string itemHg)
        {
            //������ ����UI ������Ʈ
            itemUIDescription.SetDescription(itemImage, name, description);
            itemUIDescription.SetEfficacy(name, itemHp , itemHg);

            //��� ������ �׵θ� ��Ȱ��ȭ �޼��� ȣ��
            DeselecAllItes();

            //������ �������� �׵θ� Ȱ��ȭ 
            _listOfUIItme[itemIndex].Select();

            currentItemHp = itemHp;
            currentItemHg = itemHg;
            ItemIndex = itemIndex;



        }

     


        //�ε����� ��ġ�� �������� �����͸� ������Ʈ 
        public void UpdateData(int itemIndex, Sprite itemImage)
        {
            if (_listOfUIItme.Count > itemIndex)
            {
                //�������� �̹����� ������ ������Ʈ
                _listOfUIItme[itemIndex].setData(itemImage);
               
            }
        }



        //������ �۾� ǥ��
        private void HendleshowItemActions(UIinventoryItem inventoryItemUI)
        {

        }

        //�巡�� ����
        private void HandleEndDrag(UIinventoryItem inventoryItemUI)
        {
            ResetDraggedItem();
        }


        //��ü ó��
        private void HandleSwap(UIinventoryItem inventoryItemUI)
        {
            int index = _listOfUIItme.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }

            OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
            //������ ���� ó�� ȣ��
            HandleItemSelection(inventoryItemUI);

        }

        //�巡�� ����� ȣ��
        private void ResetDraggedItem()
        {
            MousFolloer.Toggle(false);
            currentlyDraggedItemIndex = -1;
        }

        //�巡�� ���� ó��
        private void HandleBeginDrag(UIinventoryItem inventoryItemUI)
        {
            //IndexOf : ó������ ��Ÿ���� �ε��� ��ȯ
            int index = _listOfUIItme.IndexOf(inventoryItemUI);

            if (index == -1)
                return;

            currentlyDraggedItemIndex = index;
            //������ ���� ó�� ȣ��
            HandleItemSelection(inventoryItemUI);
            OnStartDragging?.Invoke(index);
        }

        //�巡�� ���� �����϶� ȣ��
        public void CreateDraggedItem(Sprite sprite )
        {
            MousFolloer.Toggle(true);
            MousFolloer.SetData(sprite);
        }

        //������ ���� ó��
        public void HandleItemSelection(UIinventoryItem inventoryItemUI)
        {
            //������ �������� ����Ʈ���� ���°���� ������
            int index = _listOfUIItme.IndexOf(inventoryItemUI);

            //�ε����� 1�̸� ����
            if (index == -1)
                return;

            //�ƴϸ� ������ ���� ��û
            OnDescriptionRequested?.Invoke(index);
        }

        //Ȱ��ȭ ������
        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
        }


        public void ResetSelection()
        {
            //������ ���� �޼��� ȣ�� 
            itemUIDescription.ResetDescription();
            DeselecAllItes();
        }

        // ��� �������� ���� ��Ȱ��ȭ 
        public void DeselecAllItes()
        {
            foreach (UIinventoryItem item in _listOfUIItme)
            {
                item.Deselect();//�׵θ� ��Ȱ��ȭ 
            }
        }

        //��Ȱ��ȭ ����
        public void Hide()
        {
            gameObject.SetActive(false);
            ResetDraggedItem();//�巡�� ���� �޼���
        }

        public void UseBottonClik(InventorySo InventoryData)
        {
            // ���� ���õ� �������� �ִ��� Ȯ��
            if (ItemIndex >= 0 && ItemIndex < _listOfUIItme.Count)
            {
                // �������� ����Ʈ���� ��������
                UIinventoryItem selectedItem = _listOfUIItme[ItemIndex];

                if (selectedItem != null)
                {
                    DataManager.Instance.CompleteMission(2);
                    Debug.Log("�������� ����Ͽ� �����͸� �ʱ�ȭ�մϴ�.");

                    // HP�� HG ���
                    PlayerManager.instance.UseHp(string.IsNullOrEmpty(currentItemHp) ? "0" : currentItemHp);
                    PlayerManager.instance.UseHg(string.IsNullOrEmpty(currentItemHg) ? "0" : currentItemHg);

                    // ���� ������ ���� UI �ʱ�ȭ
                    itemUIDescription.ResetDescription();

                    // ������ �ε����� �������� �κ��丮���� ����
                    InventoryData.Removeitem(ItemIndex);

                    // UI������ ������ ����
                    selectedItem.DestroyData();

                    // ���õ� ������ �ε����� �ʱ�ȭ (�� �̻� ���õ� �������� ����)
                    ItemIndex = -1;

                    Debug.Log("�������� ���������� ���ǰ� ���ŵǾ����ϴ�.");
                }
            }
            else
            {
                Debug.LogError("���õ� �������� ���ų� �ε����� ��ȿ���� �ʽ��ϴ�.");
            }
        }


    }
}