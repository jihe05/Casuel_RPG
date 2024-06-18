using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIinventoryItem : MonoBehaviour
{
    [SerializeField]
    private Image ItemImage;

    [SerializeField]
    private TextMeshProUGUI CountText;

    [SerializeField]
    private Image borderImage;//�׵θ�

    //�׸��� Ŭ�� ��, ������ ��� �� , ������ �巡�� ���� ��, ������ �巡�� ���� ��,���콺 ������ ��ư Ŭ�� ��
    public event Action<UIinventoryItem> OnItemClicked,
        OnItemDroppedOn, OnItemBegingDrag, OnItemEndDrag , OnRightMouseBtnClick;

    //������ ����ִ°�
    private bool empty = true;


    private void Start()
    {
        gameObject.transform.localScale = Vector3.one;
    }

    private void Awake()
    {
      
        ResetData();
        Deselect();
    }

    //������ �����͸� �ʱ�ȭ�ϸ� ������ ���
    public void ResetData()
    {
        this.ItemImage.gameObject.SetActive(false);
        empty = true;
    }

    //������ �����͸� �����Ͽ� ������ ä��
    public void setData(Sprite sprite, int quantity)
    {
        this.ItemImage.gameObject.SetActive(true);
        this.ItemImage.sprite = sprite;
        this.CountText.text = quantity + "";

    }


    //������ �������� ��Ȱ��ȭ
    public void Deselect()
    {
        borderImage.enabled = false;
    }

    //������ �׵θ��� Ȱ��ȭ
    public void Select()
    {
        borderImage.enabled = true;
    }

    //�巡�׸� �����Ҷ� ȣ��
    public void OnBeginDrag()
    { 
        if (empty)
            return;
        //������� ���� ��쿡�� �̺�Ʈ ����
        OnItemBegingDrag?.Invoke(this);
    }


    //�巡�� ����
    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    //���
    public void OnDrop()
    { 
       OnItemDroppedOn?.Invoke(this);
    }

    //Ŭ�� �� �̺�Ʈ�� ó�� 
    public void OnPointerClick(BaseEventData data)
    {
        if (empty)
            return;
        
        //�̺�Ʈ �����͸� ����Ʈ �̺�Ʈ �����ͷ� ĳ����
        PointerEventData pointerData = (PointerEventData)data;

        //��ư�� Ŭ��������
        if (pointerData.button == PointerEventData.InputButton.Right)
        { 
            //��ư Ŭ�� �̺�Ʈ �߻�
           OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            //�Ϲ� Ŭ�� �̺�Ʈ �߻�
            OnItemClicked?.Invoke(this);
        }
    }


}
