using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIinventory : MonoBehaviour
{
 
    [SerializeField]
    private UIinventoryItem itmePrefab;//인벤 아이템 요소생성

    [SerializeField]
     private RectTransform contentPanel;//배치될 패널

    [SerializeField]
    private UIInventoryDescription inventoryItemUIDescription;

    [SerializeField]
    private ItemMousFolloer MousFolloer;

    List<UIinventoryItem> _listOfUIItme = new List<UIinventoryItem>();

    private event Action<int> 
        OnDescriptionRequested, OnItemactionRequsted, OnStartDragging;

    public event Action<int, int> OnSwapItems;

    //currentlyDraggedItemIndex : 현재 드래그 중인 아이템 인덱스
    private int currentlyDraggedItemIndex = -1;

    private void Awake()
    {
        Hide();
        MousFolloer.Toggle(false);
        inventoryItemUIDescription.ResetDescription();
    }

    //UI Size초기화 
    public void InitalizeInventoryUI(int inventorysize)
    {
        //인벤토리의 크기 만큼 반복
        for (int i = 0; i < inventorysize; i++)
        {
            //inventoryItemUI의 정보 가져오기
            UIinventoryItem uiItme = Instantiate(itmePrefab, Vector3.zero, Quaternion.identity);

            //생성될 위치
            uiItme.transform.SetParent(contentPanel);

            //추가
            _listOfUIItme.Add(uiItme);
            uiItme.OnItemClicked += HandleItemSelection;
            uiItme.OnItemBegingDrag += HandleBeginDrag;
            uiItme.OnItemDroppedOn += HandleSwap;
            uiItme.OnItemEndDrag += HandleEndDrag;
            uiItme.OnRightMouseBtnClick += HendleshowItemActions;
              

        } 
    
    }

    //인덱스의 위치한 아이템의 데이터를 업데이트 
    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if (_listOfUIItme.Count > itemIndex)
        {
            //아이템의 이미지와 수량을 업데이트
            _listOfUIItme[itemIndex].setData(itemImage, itemQuantity);
        }
    }
    
       
    

    //아이템 작업 표시
    private void HendleshowItemActions(UIinventoryItem inventoryItemUI)
    {

    }

    //드래그 종료
    private void HandleEndDrag(UIinventoryItem inventoryItemUI)
    {
        ResetDraggedItem();
    }


    //교체 처리
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

    //드래그 시작 처리
    private void HandleBeginDrag(UIinventoryItem inventoryItemUI)
    {
        //IndexOf : 처음으로 나타나는 인덱스 반환
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

    //아이템 선택 처리
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
        //아이템 설명 메서드 호출 
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
