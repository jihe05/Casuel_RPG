using Inventory.Model;
using Ivnentory;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UImanger : MonoBehaviour
{

    
    //___________________Coin_________________________

    public static UImanger Instance { get; private set; }

    [Header("-Coin-")]
    public Text Text_playercoin;

    public int Coin = 10000;

    private void Awake()
    {
        Instance = this;
        StartCoin();
    }

    public void StartCoin()
    {
        Text_playercoin.text = Coin.ToString("N0");

    }

    public void UpdataCoinAndImage(int _coin , Sprite itemImage)
    {
        if (_coin < Coin  && Coin != 0)
        {
            Coin -= _coin;
            _coin = Coin;
            Text_playercoin.text = _coin.ToString("N0");

            Debug.Log("1");
            InventoryUpdate(itemImage);
            Debug.Log("5");
  
        }
        else
        {
            return;

        }
      

    }

    //_________________________________________________________



    [Header("-Inventory-")]
    //_____________________Inventory___________________________


    [SerializeField]
    private InventorySo inventoryData;

    private void InventoryUpdate(Sprite itemImage)
    {
        Debug.Log("2");
        Item item = itemImage.GetComponent<Item>();
        Debug.Log("3");

        if (item != null)
        {
            Debug.Log("4");
            int reminder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
            Debug.Log("reminder : " + reminder);
            item.Quantity = reminder;

        }
        else
        {
            Debug.Log("null");
        }
    }
    //____________________________________________________________



    [Header("-Camera-")]
    //_________________________Camera_____________________________


    public Camera Selectcamera;
    public Transform newParent;
    public GameObject SelectCharacterPanel;

    // ȣ��� ������ �����̱� ����
    public void MoveLeft()
    {
        // ���� ��ġ�� �����ɴϴ�.
        Vector3 currentPosition = Selectcamera.transform.position;

        Debug.Log("currentPosition.x" + currentPosition.x);

        if (currentPosition.x <= -64)
            return;
        else
            // X ��ǥ�� -2��ŭ �̵��ϰ� Y, Z ��ǥ�� �����մϴ�.
            currentPosition.x -= 2f;



        // ����� ��ġ�� �����մϴ�.
        Selectcamera.transform.position = currentPosition;

    }


    // ȣ��� ������ �����̱� ����
    public void MoveRight()
    {
        // ���� ��ġ�� �����ɴϴ�.
        Vector3 currentPosition = Selectcamera.transform.position;

        if (currentPosition.x >= -58)
            return;
        else
            // X ��ǥ�� -2��ŭ �̵��ϰ� Y, Z ��ǥ�� �����մϴ�.
            currentPosition.x += 2f;

        // ����� ��ġ�� �����մϴ�.
        Selectcamera.transform.position = currentPosition;


    }

    public void OnMoveButtonClicked()
    {
        // ��� MoveObject ��ũ��Ʈ�� ���� ������Ʈ�� ã��
        MoveObject[] moveObjects = FindObjectsOfType<MoveObject>();
      

        foreach (MoveObject moveObject in moveObjects)
        {
            // ī�޶� ������Ʈ�� ���߰� �ִ��� Ȯ��
            if (IsObjectVisible(moveObject.transform))
            {
                // ������Ʈ�� ���ο� �θ��� �ڽ����� �̵�
                moveObject.MoveToNewParentButton(newParent);

                SelectCharacterPanel.gameObject.SetActive(false);
                Debug.Log(222);
            }
        }
    }

    // ������Ʈ�� ī�޶� ����Ʈ ���� �ִ��� Ȯ��
    private bool IsObjectVisible(Transform objectTransform)
    {
        Vector3 viewportPosition = Selectcamera.WorldToViewportPoint(objectTransform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1 && viewportPosition.z > 0;
    }


    //____________________________________________________________________

    //_____________________changePlayer_________________________

    public GameObject WomanPlayer;
    public GameObject ManPlayer;

    public void MomanButton()
    {
        if (WomanPlayer.active == false)
        {
            ManPlayer.SetActive(false);
            WomanPlayer.SetActive(true);
        }

    }

    public void ManButton()
    {
        if (ManPlayer.active == false)
        {
            WomanPlayer.SetActive(false);
            ManPlayer.SetActive(true);
        }

    }





    //_________________________________________________________

}

