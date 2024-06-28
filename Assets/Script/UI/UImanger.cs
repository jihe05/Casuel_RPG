using Inventory.Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UImanger : MonoBehaviour
{
    public static UImanger Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        StartCoin();
        PlayerHpData();
        MonsterHpData();
    }

   
    //___________________Coin_________________________



    [Header("-Coin-")]
    public Text Text_playercoin;

    public int Coin = 10000;


    public void StartCoin()
    {
        Text_playercoin.text = Coin.ToString("N0");

    }

    public void BayCoinAndImage(int _coin , Sprite itemImage)
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

    public void CoinAndImage(int _coin)
    {
     
       Coin += _coin;
     
        Text_playercoin.text = Coin.ToString("N0");

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

    //__________________playerHp_______________________________

    public Slider Player_HpSlidebar;
    public float PlayerMaxHp = 10000;

    private void PlayerHpData()
    {
        Player_HpSlidebar.minValue = 0f;
        Player_HpSlidebar.maxValue = PlayerMaxHp;
        Player_HpSlidebar.value = PlayerMaxHp;
    }


    public void PlayerSliderbar(float Ap)
    { 
         Player_HpSlidebar.value -= Ap;
    
    }


    //_________________________________________________________

    //__________________MonsterHp_______________________________

    public Slider Monster_HpSlidebar;
    public float MonsterMaxHp = 100;

    private void MonsterHpData()
    {
        Monster_HpSlidebar.minValue = 0f;
        Monster_HpSlidebar.maxValue = MonsterMaxHp;
        Monster_HpSlidebar.value = MonsterMaxHp;
    }

    public void MonsterSliderbar(float Ap)
    {
        Debug.Log("Monster_HpSlidebar.value ; " + Monster_HpSlidebar.value);
        Debug.Log("Ap:" + Ap);
        Monster_HpSlidebar.value -= Ap;
        Debug.Log("Monster_HpSlidebar.value2:" + Monster_HpSlidebar.value);
    }

    //_________________________________________________________


}

