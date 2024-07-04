using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//UI리스트 아이템을 초기화하고 업데이트하는 클래스
public class UIListItem : MonoBehaviour
{
    public Image reward_image;//보상 이미지 
    public Text reward_amount;//보상 수량
    public Image imageName;//미션아이콘
    public Text textName;//미션 설명
    public Slider missionProgressSlider;
    public Button completButton;
    public Image checkImage;


    private MissionInfo info;//미션 정보

    public void Init(MissionInfo info)
    {
        this.info = info;
        var data = DataManager.Instance.dicMissionDatas[this.info.id];
        this.textName.text = string.Format(data.mission_desc, data.goal);

        // 스프라이트 경로를 업데이트된 경로로 설정
        var path = string.Format("UI/ResourceData/Sprites/Demo/Demo_Icon/{0}", data.sprite_name);
        Debug.Log($"Loading sprite from path: {path}"); // 디버그 로그 추가

        this.imageName.sprite = Resources.Load<Sprite>(path);
        Debug.Log(Resources.Load<Sprite>(path));

        this.reward_amount.text = data.reward_amount.ToString();

        //슬라이더 버튼 초기화 
        missionProgressSlider.maxValue = data.goal;
        missionProgressSlider.value = info.count;
        completButton.onClick.AddListener(OnCompleteButtonClick);

        UpdateUI();

    }

    //미션 상태를 업데이트 하는 메서드
    public void UpdateProgress(int progress)
    { 
       info.count = progress;
        missionProgressSlider.value = progress;
        UpdateUI();

    }

    //UI업데이트
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

        //미션 완료한 경우 
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

    //미션 완료 버튼
    private void OnCompleteButtonClick()
    {
       info.state = 1;
        UpdateUI();
    }
}
