using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsManager : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;
    public Dropdown antiAliasingDropdown;

    //�ػ� �迭
    private Resolution[] resolutions;

    void Start()
    {
        InitializeResolutionOptions();
        InitializeFullscreenOption();
        InitializeVSyncOption();
        InitializeAntiAliasingOptions();
    }

    //�ػ� �ɼ� �ʱ�ȭ 
    void InitializeResolutionOptions()
    {
        resolutions = Screen.resolutions; //��밡���� �ػ� ��������
        resolutionDropdown.ClearOptions();//DropDown�ɼ� ���� 
        List<string> options = new List<string>(); //DropDown�ɼ��� �߰��� ����Ʈ
        int currentResolutionIndex = 0;

        //�ɼ� �߰� 
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            //���� �ػ󵵿� ��ġ�ϴ� �ػ� ã��
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);//�߰�
        resolutionDropdown.value = currentResolutionIndex;//����
        resolutionDropdown.RefreshShownValue();//������Ʈ
        resolutionDropdown.onValueChanged.AddListener(SetResolution);//����
    }

    //��üȭ�� �ɼ� �ʱ�ȭ 
    void InitializeFullscreenOption()
    {
        //��äȭ�� ���·� ����
        fullscreenToggle.isOn = Screen.fullScreen;
        //üȭ������ ����
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    //V-Sync�ɼ� �ʱ�ȭ 
    void InitializeVSyncOption()
    {
        //���� V-Sync ���·� ����
        vsyncToggle.isOn = QualitySettings.vSyncCount > 0;
        //V-Sync ���� �� ȣ��� �޼��� ����
        vsyncToggle.onValueChanged.AddListener(SetVSync);
    }

    //���׾ٸ���� �ɼ� �ʱ�ȭ
    void InitializeAntiAliasingOptions()
    {
        //Dropdown�� ���� �ɼ� ����
        antiAliasingDropdown.ClearOptions();
        //��Ƽ�ٸ���� �ɼ� ����Ʈ
        List<string> options = new List<string> { "None", "2x", "4x", "8x" };
        //Dropdown�� �ɼ� �߰�
        antiAliasingDropdown.AddOptions(options);
        //���� ��Ƽ�ٸ���� ������ ����
        antiAliasingDropdown.value = QualitySettings.antiAliasing / 2;
        //Dropdown UI ������Ʈ
        antiAliasingDropdown.RefreshShownValue();
        //��Ƽ�ٸ���� ���� �� ȣ��� �޼��� ����
        antiAliasingDropdown.onValueChanged.AddListener(SetAntiAliasing);

    }

    //�ػ󵵸� �����ϴ� �޼���
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex]; //���õ� �ػ󵵷� ����
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //�ػ� ����
    }

    //��üȭ���� �����ϴ� �޼���
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; //��üȭ�� ��� ����
    }

    //V-Sync�� �����ϴ� �޼���
    public void SetVSync(bool isVSync)
    {
        QualitySettings.vSyncCount = isVSync ? 1 : 0; //V-Sync ����
    }

    //��Ƽ�ٸ������ �����ϴ� �޼���
    public void SetAntiAliasing(int antiAliasingIndex)
    {
        QualitySettings.antiAliasing = antiAliasingIndex * 2; //��Ƽ�ٸ���� ����
    }
}