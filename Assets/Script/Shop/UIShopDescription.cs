using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopDescription : MonoBehaviour
{
    public static UIShopDescription instance;

    public Text title;//������ �̸�

    //������ ȿ��
    public Text stats;


    public void Awake()
    {
        instance = this;
        ResetShopDescription();
    }

    //���� �ʱ�ȭ
    public void ResetShopDescription()
    {
        title.text = string.Empty;
        stats.text = string.Empty;
    }

    //���� ����
    public void SetShopDescription(string itmeName)
    {
        title.text = itmeName;

    }

    //���� ���� ����
    public void SetShopEfficacy(string itemName, string itemHp, string itemHg)
    {
        title.text = itemName;
        stats.text = $"itemHp : {itemHp} \n itemHg : {itemHg}";

    }
}
