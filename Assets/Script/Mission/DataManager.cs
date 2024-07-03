using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public Dictionary<int, MissionData> dicMissionDatas;
    public Dictionary<int, MissionReqsrData> dicMissionRewardata;

    private DataManager() { }

    //�̱��� �ν��Ͻ��� ��ȯ�ϴ� �޼��� 
   public static DataManager GetInstance()
    {
        if (DataManager.instance == null)
        { 
          DataManager.instance = new DataManager();
        }
        return DataManager.instance;
   }
    
    //������ �ε� �޼��� " Json������ �о�ͼ� ��ųʸ��� ����
}
