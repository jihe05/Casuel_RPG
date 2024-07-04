using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;


public class DataManager : MonoBehaviour
{
    private static DataManager instance; //�̱��� �ν��Ͻ� 
    public static DataManager Instance => instance; //�ν��Ͻ� ������

    public MissionData[] missionDatas; //�̼� ������ �迭
    public MissionRewardData[] missionRewardDatas; //�̼� ���� ������ �迭

    public Dictionary<int, MissionData> dicMissionDatas;
    public Dictionary<int, MissionRewardData> dicMissionRewardDatas;

    private void Awake()
    {
        instance = this;
        InitalixeDictionaries();
    }

    //��ųʸ� �ʱ�ȭ 
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
