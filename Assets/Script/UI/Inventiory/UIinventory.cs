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
    private UIInventoryDescription itemDescription;

    List<UIinventoryItem> _listOfUIItme = new List<UIinventoryItem>();

    public Sprite image;
    public int quantity;
    public string title, description;

    private void Awake()
    {
        Hide();
        itemDescription.ResetDescription();
    }

    //UI Size초기화 
    public void InitalizeInventoryUI(int inventorysize)
    {
        //인벤토리의 크기 만큼 반복
        for (int i = 0; i < inventorysize; i++)
        {
            //item의 정보 가져오기
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

    private void HendleshowItemActions(UIinventoryItem item)
    {

    }

    private void HandleEndDrag(UIinventoryItem item)
    {

    }

    private void HandleSwap(UIinventoryItem item)
    {

    }

    private void HandleBeginDrag(UIinventoryItem item)
    {

    }

    private void HandleItemSelection(UIinventoryItem item)
    {
        Debug.Log("item : " + item.name);
        itemDescription.SetDescription(image, title, description);
        _listOfUIItme[0].Select();
    }

    public void Show()
    { 
      gameObject.SetActive(true);

      //아이템 설명 메서드 호출 
      itemDescription.ResetDescription();

       _listOfUIItme[0].setData(image, quantity);

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
