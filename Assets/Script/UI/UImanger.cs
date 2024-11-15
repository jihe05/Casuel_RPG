using UnityEngine;
using UnityEngine.UI;



public class UImanger : MonoBehaviour
{
    public static UImanger Instance { get; private set; }

    [Header("-Coin-")]
    public Text text_playercoin;
    public int coin = 10000;

    [Header("-Inventory-")]
    public GameObject itemUseButton;

    [Header("-Camera-")]
    public Camera selectcamera;
    public Transform newParent;
    public GameObject selectCharacterPanel;

    [Header("-changePlayer-")]
    public GameObject womanPlayer;
    public GameObject manPlayer;


    [Header("-playerHp-")]
    public Slider player_HpSlidebar;
    public float playerMaxHp = 10000;

    [Header("-playerHg-")]
    public Slider player_HgSlider;
    public float playerMaxHg = 50f;


    [Header("-MonsterHp-")]
    public GameObject monster_HpSlidebarPrefab; // HP �� ������
    public float monsterMaxHp = 3000;
  


    [Header("-Boss-")]
    public GameObject bossBa;
    public Slider boss_HpSlidebar;
    public float bossMaxHp;


    [Header("-SettingButtonActive-")]
    public GameObject soundPanel;
    public GameObject graphicspanel;
    public GameObject controlPanel;

    [Header("-EventButton-")]
    public GameObject event_Button;

    [Header("LevelUp")]
    public GameObject levelUP_Text;
    public Text level;

    [Header("Endingpanel")]
    public GameObject endingpanel;

    [Header("EventGuidUI")]
    public GameObject eventGuidUI;

    [Header("Playername")]
    public Text playername;

    [Header("ShopMasage")]
    public Text shopMasage;

    [Header("Missionpanel")]
    public GameObject missionpanel;

    [Header("coinmission")]
    public Text coinT;
    int count = 0;

    private void Awake()
    {
        Instance = this;
        StartCoin();
        PlayerHpData();
        PlayerHGData();
        bossBa.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (event_Button.activeSelf == true && Input.GetKeyDown(KeyCode.F))
        {
            EventManager.Instans.TreasurBox();
            Invoke("SetActiveBox", 3f);
        }
    }

    public void StartCoin()
    {
        text_playercoin.text = coin.ToString("N0");

    }

    public void BayCoinAndImage(int _coin)
    {
        if (_coin < coin && coin != 0)
        {
            coin -= _coin;
            _coin = coin;
            text_playercoin.text = _coin.ToString("N0");

        }
        else
        {
            return;
        }

    }

    public void CoinAndImage(int _coin)
    {
        coin += _coin;
        text_playercoin.text = coin.ToString("N0");

        if (coin >= 15000)
        {
            DataManager.Instance.CompleteMission(6);
        }

        if (coin > 99999)
        {
            text_playercoin.text = coin.ToString("99999+");
        }
    }




    public void InventoryOnButtonUseTrue()
    {
        itemUseButton.SetActive(true);
     
    }

    public void InventoryOnButtonUseFalse()
    {
       itemUseButton.SetActive(false);

    }


    // ȣ��� ������ �����̱� ����
    public void MoveLeft()
    {
        // ���� ��ġ�� �����ɴϴ�.
        Vector3 currentPosition = selectcamera.transform.position;

        if (currentPosition.x <= -64)
            return;
        else
            // X ��ǥ�� -2��ŭ �̵��ϰ� Y, Z ��ǥ�� �����մϴ�.
            currentPosition.x -= 2f;



        // ����� ��ġ�� �����մϴ�.
        selectcamera.transform.position = currentPosition;

    }


    // ȣ��� ������ �����̱� ����
    public void MoveRight()
    {
        // ���� ��ġ�� �����ɴϴ�.
        Vector3 currentPosition = selectcamera.transform.position;

        if (currentPosition.x >= -58)
            return;
        else
            // X ��ǥ�� -2��ŭ �̵��ϰ� Y, Z ��ǥ�� �����մϴ�.
            currentPosition.x += 2f;

        // ����� ��ġ�� �����մϴ�.
        selectcamera.transform.position = currentPosition;


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
                selectCharacterPanel.gameObject.SetActive(false);

            }
        }
    }

    // ������Ʈ�� ī�޶� ����Ʈ ���� �ִ��� Ȯ��
    private bool IsObjectVisible(Transform objectTransform)
    {
        Vector3 viewportPosition = selectcamera.WorldToViewportPoint(objectTransform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1 && viewportPosition.z > 0;
    }



    public void MomanButton()
    {
        if (manPlayer.activeSelf == true)
        {
            manPlayer.SetActive(false);
            womanPlayer.SetActive(true);
        }

    }

    public void ManButton()
    {
        if (womanPlayer.activeSelf == true)
        {
            womanPlayer.SetActive(false);
            manPlayer.SetActive(true);
        }

    }



    private void PlayerHpData()
    {
        player_HpSlidebar.minValue = 0f;
        player_HpSlidebar.maxValue = playerMaxHp;
        player_HpSlidebar.value = playerMaxHp;

    }


    public void PlayerSliderbarDamege(float Ap)
    {
        player_HpSlidebar.value -= Ap;

    }


    public void PlayerSliderbarHp(float playerHp)
    {
        player_HpSlidebar.value = playerHp;

    }

    public void PlayerSliderbarAddHp(float playerHp)
    {
        player_HpSlidebar.value += playerHp;

    }


    private void PlayerHGData()
    {
        player_HgSlider.minValue = 0f;
        player_HgSlider.maxValue = playerMaxHg;
        player_HgSlider.value = playerMaxHg;

    }

    public void PlayerSliderbarHgUse(float Hg)
    {
        
        player_HgSlider.value -= Hg;
    }

  
    public void PlayerSliderbarHg(int Hg)
    {
        player_HgSlider.value += Hg;
    }



    public void MonsterHpData(GameObject monster)
    {
        GameObject hpBarInstance = Instantiate(monster_HpSlidebarPrefab, monster.transform);
        Slider slider = hpBarInstance.GetComponentInChildren<Slider>();

        slider.minValue = 0f;
        slider.maxValue = monsterMaxHp;
        slider.value = monsterMaxHp;
        hpBarInstance.transform.localPosition = new Vector3(0, 1.0f, 0);  //���� ����
    }

    public void MonsterSliderbar(Slider slider, float monsterHP)
    {
        slider.value = monsterHP;
    }


    public void ShowHpBa()
    {
        bossBa.gameObject.SetActive(true);
    }

    public void HideHpBa()
    {
        bossBa.gameObject.SetActive(false);
    }


    public void HpBa()
    {
        bossBa.gameObject.SetActive(true);
    }


    public void BossSliderbar(float BossMaxHp)
    {
        bossMaxHp = BossMaxHp;
        boss_HpSlidebar.minValue = 0f;
        boss_HpSlidebar.maxValue = bossMaxHp;
        boss_HpSlidebar.value = bossMaxHp;


    }

    public void BossSligerBarHp(float BoosAp)
    {
        boss_HpSlidebar.value = BoosAp;

    }

    public void OnClickButtonActive(GameObject targetObject)
    {
        // GameObject�� ��Ȱ��ȭ �����̸� Ȱ��ȭ�ϰ�, Ȱ��ȭ �����̸� ��Ȱ��ȭ
        if (!targetObject.activeSelf)
        {
            targetObject.SetActive(true);
        }
        else
        {
            targetObject.SetActive(false);
        }
    }



    public void OnClickSettingButton(GameObject butonPanle)
    {
        //Ȱ��ȭ�� ���ΰ� 
        if (butonPanle.activeSelf)
        {
            return;
        }
        else
        {
            //�ƴϸ� �� ��Ȱ��ȭ 
            soundPanel.SetActive(false);
            graphicspanel.SetActive(false);
            controlPanel.SetActive(false);

            butonPanle.SetActive(true);
        }

    }

    

    //��ư Ȱ��ȭ 
    public void EventButton()
    {
        event_Button.SetActive(true);

        
       
    }

    public void SetActiveBox()
    {
        event_Button.SetActive(false);
        EventManager.Instans.TreasurBoxSetActive();
    }


    

    public void PlayerlevelUp(int level)
    {
        levelUP_Text.SetActive(true);
        this.level.text = level.ToString();

        Invoke("PlayerlevelUpfalse", 1);
    }

    public void PlayerlevelUpfalse()
    {
        levelUP_Text.SetActive(false);

    }




    public void EndingpaenlActive()
    {
        endingpanel.SetActive(true);


    }

 

    public void EventGuidCollider()
    {
        if (eventGuidUI.activeSelf == false)
        {
            eventGuidUI.SetActive(true);

        }
        else
            return;

        Invoke("DestroyUI", 1.3f);
    }

    public void DestroyUI()
    {
        eventGuidUI.SetActive(false);

    }

    public void PlyerName(string id)
    {
        playername.text = id;
    }

    public void ShopMasageTrue()
    { 
       shopMasage.enabled = true;
        Invoke(nameof(ShopMasageFalse), 0.5f);
    }

    public void ShopMasageFalse()
    {
        
        shopMasage.enabled = false;
    }

    public void MissionActive()
    {
        missionpanel.SetActive(false);
    }

    public void Eixt_OnClickButton()
    {    
      #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;  // �����Ϳ��� ���� ����
      #else
          Application.Quit();  // ����� ���ø����̼ǿ����� ���� ����
      #endif
    }

    public void CoinCount()
    {
        count ++;

        coinT.text = count.ToString();


    }

}

