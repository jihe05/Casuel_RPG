using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsManager : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;
    public Dropdown antiAliasingDropdown;

    //해상도 배열
    private Resolution[] resolutions;

    void Start()
    {
        InitializeResolutionOptions();
        InitializeFullscreenOption();
        InitializeVSyncOption();
        InitializeAntiAliasingOptions();
    }

    //해상도 옵션 초기화 
    void InitializeResolutionOptions()
    {
        resolutions = Screen.resolutions; //사용가능한 해상도 가져오기
        resolutionDropdown.ClearOptions();//DropDown옵션 삭제 
        List<string> options = new List<string>(); //DropDown옵션의 추가할 리스트
        int currentResolutionIndex = 0;

        //옵션 추가 
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            //현재 해상도와 일치하는 해상도 찾음
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);//추가
        resolutionDropdown.value = currentResolutionIndex;//설정
        resolutionDropdown.RefreshShownValue();//업데이트
        resolutionDropdown.onValueChanged.AddListener(SetResolution);//변경
    }

    //전체화면 옵션 초기화 
    void InitializeFullscreenOption()
    {
        //전채화면 상태로 설정
        fullscreenToggle.isOn = Screen.fullScreen;
        //체화면으로 변경
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    //V-Sync옵션 초기화 
    void InitializeVSyncOption()
    {
        //현재 V-Sync 상태로 설정
        vsyncToggle.isOn = QualitySettings.vSyncCount > 0;
        //V-Sync 변경 시 호출될 메서드 설정
        vsyncToggle.onValueChanged.AddListener(SetVSync);
    }

    //안테앨리어싱 옵션 초기화
    void InitializeAntiAliasingOptions()
    {
        //Dropdown의 기존 옵션 삭제
        antiAliasingDropdown.ClearOptions();
        //안티앨리어싱 옵션 리스트
        List<string> options = new List<string> { "None", "2x", "4x", "8x" };
        //Dropdown에 옵션 추가
        antiAliasingDropdown.AddOptions(options);
        //현재 안티앨리어싱 값으로 설정
        antiAliasingDropdown.value = QualitySettings.antiAliasing / 2;
        //Dropdown UI 업데이트
        antiAliasingDropdown.RefreshShownValue();
        //안티앨리어싱 변경 시 호출될 메서드 설정
        antiAliasingDropdown.onValueChanged.AddListener(SetAntiAliasing);

    }

    //해상도를 설정하는 메서드
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex]; //선택된 해상도로 설정
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //해상도 변경
    }

    //전체화면을 설정하는 메서드
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; //전체화면 모드 변경
    }

    //V-Sync를 설정하는 메서드
    public void SetVSync(bool isVSync)
    {
        QualitySettings.vSyncCount = isVSync ? 1 : 0; //V-Sync 설정
    }

    //안티앨리어싱을 설정하는 메서드
    public void SetAntiAliasing(int antiAliasingIndex)
    {
        QualitySettings.antiAliasing = antiAliasingIndex * 2; //안티앨리어싱 설정
    }
}