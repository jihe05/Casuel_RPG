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

    //싱글톤 인스턴스를 반환하는 메서드 
   public static DataManager GetInstance()
    {
        if (DataManager.instance == null)
        { 
          DataManager.instance = new DataManager();
        }
        return DataManager.instance;
   }
    
    //데이터 로드 메서드 " Json파일을 읽어와서 딕셔너리에 저장
}
