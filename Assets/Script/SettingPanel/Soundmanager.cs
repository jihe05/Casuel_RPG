using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{
    public Slider masterVolumeSlider;//������ ����
    public Slider musicVolumeSlider;//���� ����
    public Slider sfxVolumeSlider;
    public Dropdown audioOutputDeviceDropdown;
    public AudioMixer audioMixer; // Audio Mixer�� ����Ͽ� ���� ����

 
    void Start()
    {
        // �ʱ� ����
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        // ������ �߰�
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);

        // ����� ��� ��ġ ���� Dropdown �ʱ�ȭ
        InitializeAudioOutputDevices();

        // ����� ��� ��ġ ���� ������ �߰�
        audioOutputDeviceDropdown.onValueChanged.AddListener(SetAudioOutputDevice);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetVoiceChatVolume(float volume)
    {
        audioMixer.SetFloat("VoiceChatVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VoiceChatVolume", volume);
    }

    private void InitializeAudioOutputDevices()
    {
        // ����� ��� ��ġ ��� �ʱ�ȭ
        // �� �κ��� �ܺ� ���̺귯���� �÷����� ������ ���� �����ؾ� �մϴ�.
        // ���÷� �⺻ ���� �߰��ϰڽ��ϴ�.
        audioOutputDeviceDropdown.ClearOptions();
       // audioOutputDeviceDropdown.AddOptions(new List<string> { "Default Device" });
    }

    public void SetAudioOutputDevice(int index)
    {
        // ����� ��� ��ġ ���� ���� �߰�
        // �� �κ��� �ܺ� ���̺귯���� �ý��� ������ ���� �����ؾ� �մϴ�.
        Debug.Log("Audio output device changed to: " + audioOutputDeviceDropdown.options[index].text);
    }
}

