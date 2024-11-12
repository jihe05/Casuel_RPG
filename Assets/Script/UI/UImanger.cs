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
    public GameObject monster_HpSlidebarPrefab; // HP 바 프리팹
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




    
    // 호출될 때마다 움직이기 시작
    public void MoveLeft()
    {
        // 현재 위치를 가져옵니다.
        Vector3 currentPosition = selectcamera.transform.position;

        if (currentPosition.x <= -64)
            return;
        else
            // X 좌표를 -2만큼 이동하고 Y, Z 좌표는 고정합니다.
            currentPosition.x -= 2f;



        // 변경된 위치를 설정합니다.
        selectcamera.transform.position = currentPosition;

    }


    // 호출될 때마다 움직이기 시작
    public void MoveRight()
    {
        // 현재 위치를 가져옵니다.
        Vector3 currentPosition = selectcamera.transform.position;

        if (currentPosition.x >= -58)
            return;
        else
            // X 좌표를 -2만큼 이동하고 Y, Z 좌표는 고정합니다.
            currentPosition.x += 2f;

        // 변경된 위치를 설정합니다.
        selectcamera.transform.position = currentPosition;


    }

    public void OnMoveButtonClicked()
    {
        // 모든 MoveObject 스크립트를 가진 오브젝트를 찾고
        MoveObject[] moveObjects = FindObjectsOfType<MoveObject>();

        foreach (MoveObject moveObject in moveObjects)
        {
            // 카메라가 오브젝트를 비추고 있는지 확인
            if (IsObjectVisible(moveObject.transform))
            {
                // 오브젝트를 새로운 부모의 자식으로 이동
                moveObject.MoveToNewParentButton(newParent);
                selectCharacterPanel.gameObject.SetActive(false);

            }
        }
    }

    // 오브젝트가 카메라 뷰포트 내에 있는지 확인
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
        hpBarInstance.transform.localPosition = new Vector3(0, 1.0f, 0);  //높이 설정
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
        // GameObject가 비활성화 상태이면 활성화하고, 활성화 상태이면 비활성화
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
        //활서화면 냅두고 
        if (butonPanle.activeSelf)
        {
            return;
        }
        else
        {
            //아니면 다 비활성화 
            soundPanel.SetActive(false);
            graphicspanel.SetActive(false);
            controlPanel.SetActive(false);

            butonPanle.SetActive(true);
        }

    }

    

    //버튼 활성화 
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
          UnityEditor.EditorApplication.isPlaying = false;  // 에디터에서 게임 종료
      #else
          Application.Quit();  // 빌드된 애플리케이션에서는 실제 종료
      #endif
    }

    public void CoinCount()
    {
        count ++;

        coinT.text = count.ToString();


    }

}

