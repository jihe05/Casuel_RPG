using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̼� �����͸� ����
[Serializable]
public class MissionData
{
    public int id; //�̼� Id
    public string missin_desc; //�̼� ����
    public int goal; //�̼� ���
    public int reward_id; //���� Id
    public int reward_amount;//���� ����
    public int btn_state;//��ư ����
    public string sprite_name;//�̹��� �̸�

}

//�̼� ������ �ʱ�ȭ�ϰ� �����ϴ� Ŭ����
public class MissionInfo
{

    public int id; //�̼� Id
    public int count;//�̼� ���൵
    public int state;//�̼� ����

    public MissionInfo(int id, int count, int state)
    {
        this.id = id;
        this.count = count;
        this.state = state;

    }


}

//�̼� ���� �����͸� �����ϴ� Ŭ����
[Serializable]
public class MissionReqsrData
{
    public int id;
    public string name;
}