using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIinventory : MonoBehaviour
{
 
    [SerializeField]
    private UIinventoryItem itmePrefab;//�κ� ������ ��һ���

    [SerializeField]
     private RectTransform contentPanel;//��ġ�� �г�

    [SerializeField]
    private UIInventoryDescription inventoryItemUIDescription;

    [SerializeField]
    private ItemMousFolloer MousFolloer;

    List<UIinventoryItem> _listOfUIItme = new List<UIinventoryItem>();

    private event Action<int> 
        OnDescriptionRequested, OnItemactionRequsted, OnStartDragging;

    public event Action<int, int> OnSwapItems;

    //currentlyDraggedItemIndex : ���� �巡�� ���� ������ �ε���
    private int currentlyDraggedItemIndex = -1;

    private void Awake()
    {
        Hide();
        MousFolloer.Toggle(false);
        inventoryItemUIDescription.ResetDescription();
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
            uiItme.OnItemClicked += HandleItemSelection;
            uiItme.OnItemBegingDrag += HandleBeginDrag;
            uiItme.OnItemDroppedOn += HandleSwap;
            uiItme.OnItemEndDrag += HandleEndDrag;
            uiItme.OnRightMouseBtnClick += HendleshowItemActions;
              

        } 
    
    }

    //�ε����� ��ġ�� �������� �����͸� ������Ʈ 
    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if (_listOfUIItme.Count > itemIndex)
        {
            //�������� �̹����� ������ ������Ʈ
            _listOfUIItme[itemIndex].setData(itemImage, itemQuantity);
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
    }

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
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }

    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        MousFolloer.Toggle(true);
        MousFolloer.SetData(sprite, quantity);
    }

    //������ ���� ó��
    private void HandleItemSelection(UIinventoryItem inventoryItemUI)
    {
        int index = _listOfUIItme.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);
    }

    public void Show()
    { 
      gameObject.SetActive(true);
      ResetSelection();

    }

    private void ResetSelection()
    {
        //������ ���� �޼��� ȣ�� 
        inventoryItemUIDescription.ResetDescription();
        DeselecAllItes();
    }

    private void DeselecAllItes()
    {
        foreach (UIinventoryItem item in _listOfUIItme)
        { 
          item.Deselect();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ResetDraggedItem();
    }


}
