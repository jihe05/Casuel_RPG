using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;


public class DataManager : MonoBehaviour
{
    private static DataManager instance; //싱글톤 인스턴스 
    public static DataManager Instance => instance; //인스턴스 접근자

    public MissionData[] missionDatas; //미션 데이터 배열
    public MissionRewardData[] missionRewardDatas; //미션 보상 데이터 배열

    public Dictionary<int, MissionData> dicMissionDatas;
    public Dictionary<int, MissionRewardData> dicMissionRewardDatas;

    private void Awake()
    {
        instance = this;
        InitalixeDictionaries();
    }

    //딕셔너리 초기화 
    private void InitalixeDictionaries()
    { 
        dicMissionDatas = new Dictionary<int, MissionData>();
        dicMissionRewardDatas =  new Dictionary<int, MissionRewardData>();

        foreach (var data in missionDatas)
        {
            dicMissionDatas.Add(data.id, data);

        }
        foreach (var reward in missionRewardDatas)
        {
            dicMissionRewardDatas.Add(reward.id, reward);
        }

        Debug.LogFormat("Load completed! Missions: {0}, Rewards: {1}", dicMissionDatas.Count, dicMissionRewardDatas.Count);

    }

}
