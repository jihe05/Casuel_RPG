using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//UI����Ʈ �������� �ʱ�ȭ�ϰ� ������Ʈ�ϴ� Ŭ����
public class UIListItem : MonoBehaviour
{
    public Image reward_image;//���� �̹��� 
    public Text reward_amount;//���� ����
    public Image imageName;//�̼Ǿ�����
    public Text textName;//�̼� ����
    public Slider missionProgressSlider;
    public Button completButton;
    public Image checkImage;


    private MissionInfo info;//�̼� ����

    public void Init(MissionInfo info)
    {
        this.info = info;
        var data = DataManager.Instance.dicMissionDatas[this.info.id];
        this.textName.text = string.Format(data.mission_desc, data.goal);

        // ��������Ʈ ��θ� ������Ʈ�� ��η� ����
        var path = string.Format("UI/ResourceData/Sprites/Demo/Demo_Icon/{0}", data.sprite_name);
        Debug.Log($"Loading sprite from path: {path}"); // ����� �α� �߰�

        this.imageName.sprite = Resources.Load<Sprite>(path);
        Debug.Log(Resources.Load<Sprite>(path));

        this.reward_amount.text = data.reward_amount.ToString();

        //�����̴� ��ư �ʱ�ȭ 
        missionProgressSlider.maxValue = data.goal;
        missionProgressSlider.value = info.count;
        completButton.onClick.AddListener(OnCompleteButtonClick);

        UpdateUI();

    }

    //�̼� ���¸� ������Ʈ �ϴ� �޼���
    public void UpdateProgress(int progress)
    { 
       info.count = progress;
        missionProgressSlider.value = progress;
        UpdateUI();

    }

    //UI������Ʈ
    private void UpdateUI()
    {
        if (info.count >= missionProgressSlider.maxValue)
        {
            completButton.gameObject.SetActive(true);

        }
        else
        {
            completButton.gameObject.SetActive(false);
        }

        //�̼� �Ϸ��� ��� 
        if (info.state == 1)
        {
            checkImage.gameObject.SetActive(true);
            completButton.gameObject.SetActive(false);
        }
        else
        {
            checkImage.gameObject.SetActive(false);
        }
    }

    //�̼� �Ϸ� ��ư
    private void OnCompleteButtonClick()
    {
       info.state = 1;
        UpdateUI();
    }
}
