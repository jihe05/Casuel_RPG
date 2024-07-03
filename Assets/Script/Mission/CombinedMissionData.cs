using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//미션 데이터를 저장
[Serializable]
public class MissionData
{
    public int id; //미션 Id
    public string missin_desc; //미션 설명
    public int goal; //미션 목록
    public int reward_id; //보상 Id
    public int reward_amount;//보상 수량
    public int btn_state;//버튼 상태
    public string sprite_name;//이미지 이름

}

//미션 정보를 초기화하고 저장하는 클래스
public class MissionInfo
{

    public int id; //미션 Id
    public int count;//미션 진행도
    public int state;//미션 상태

    public MissionInfo(int id, int count, int state)
    {
        this.id = id;
        this.count = count;
        this.state = state;

    }


}

//미션 보상 데이터를 저장하는 클래스
[Serializable]
public class MissionReqsrData
{
    public int id;
    public string name;
}