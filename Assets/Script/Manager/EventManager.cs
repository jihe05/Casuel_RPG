using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventManager Instans;

    [SerializeField] private GameObject Obj_Chat;
    [SerializeField] private GameObject treasurBox_Close;
    [SerializeField] private GameObject treasurBox_Open;
    [SerializeField] private GameObject EventBox;
    [SerializeField] private GameObject firstMission;
    [SerializeField] private GameObject flyTimeLine;
    [SerializeField] private GameObject EventCollider;
    [SerializeField] private ParticleSystem coinParticleSystem;
    [SerializeField] private Text missionName;
    [SerializeField] private GameObject missionAlarmPanel;
    [SerializeField] private GameObject princessMove;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject coinEvent;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject coinPnaleEvent;
    [SerializeField] private GameObject potalPaticle;
    [SerializeField] private GameObject waitColider;

    private void Awake()
    {
        Instans = this;
    }

    private void Update()
    {
        if (monster == null)
        {
            if (coinPnaleEvent.activeSelf==false)
            {
                return;
            }
            else
            {
                coinEvent.SetActive(true);
                coinPnaleEvent.SetActive(true);
                Coinmission();
            }
            
        }
    }

    private void Coinmission()
    {
        MissionCoin missionCoin = coin.GetComponentInChildren<MissionCoin>();
        if (missionCoin == null)
        {
            DataManager.Instance.CompleteMission(8);
            coinEvent.SetActive(false);
            coinPnaleEvent.SetActive(false);
            return;

        }
    }

    public void TalkePanelActive()
    {
        Obj_Chat.SetActive(true);
    }
    public void TalkePanelDestroy()
    {
        Obj_Chat.SetActive(true);

        PlayerPrefs.DeleteAll();
    }

    public void TreasurBox()
    {
        treasurBox_Close.SetActive(false);
        treasurBox_Open.SetActive(true);
        coinParticleSystem.Play();  
        DataManager.Instance.CompleteMission(4);
        UImanger.Instance.CoinAndImage(10000);
    }

    public void MissionAlarm(string _missionName)
    {
        missionAlarmPanel.SetActive(true);
        missionName.text = _missionName;
        Invoke("MissionAlarmfalse", 2);
    }

    public void MissionAlarmfalse()
    {
        missionAlarmPanel.SetActive(false);

    }


    public void TreasurBoxSetActive()
    {
        EventBox.gameObject.SetActive(false);

    }

    public void ColiderFalse()
    {
        firstMission.SetActive(false);
    }

    public void GuidFlyActive()
    {
        if (flyTimeLine.activeSelf == true)
        {
            flyTimeLine.SetActive(false);
        }
        else
        {
            flyTimeLine.SetActive(true);
        }

    }

    //호출되면 공주가 돌아서며 대화 시작
    public void Princes()
    { 
        princessMove.transform.Rotate(new Vector3 (0, 180 , 0));

        DataManager.Instance.CompleteMission(7);

       Collider princessCollider = princessMove.GetComponent<Collider>();

        princessCollider .enabled = false;  
    }

    public void PotalOpen()
    {

        potalPaticle.SetActive(true);
    }

    public void BosClider()
    {
        Bossmove.Instance.TimeLine();

        Invoke(nameof(WaitColider), 5);
        
    }

    public void WaitColider()
    {
        
        waitColider.SetActive(false);

    }

}
