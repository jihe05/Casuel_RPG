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

    //UI Size�ʱ�ȭ 
    public void InitalizeInventoryUI(int inventorysize)
    {
        //�κ��丮�� ũ�� ��ŭ �ݺ�
        for (int i = 0; i < inventorysize; i++)
        {
            //item�� ���� ��������
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

      //������ ���� �޼��� ȣ�� 
      itemDescription.ResetDescription();

       _listOfUIItme[0].setData(image, quantity);

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
