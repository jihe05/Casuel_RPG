using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{

    /*
    public Slider masterVolumeSlider;//마스터 볼륨
    public Slider musicVolumeSlider;//뮤직 볼륨
    public Slider sfxVolumeSlider;
    public Dropdown audioOutputDeviceDropdown;
    public AudioMixer audioMixer; // Audio Mixer를 사용하여 볼륨 조절

 
    void Start()
    {
        // 초기 설정
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        // 리스너 추가
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);

        // 오디오 출력 장치 선택 Dropdown 초기화
        InitializeAudioOutputDevices();

        // 오디오 출력 장치 변경 리스너 추가
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
        // 오디오 출력 장치 목록 초기화
        // 이 부분은 외부 라이브러리나 플랫폼별 설정을 통해 구현해야 합니다.
        // 예시로 기본 값만 추가하겠습니다.
        audioOutputDeviceDropdown.ClearOptions();
       // audioOutputDeviceDropdown.AddOptions(new List<string> { "Default Device" });
    }

    public void SetAudioOutputDevice(int index)
    {
        // 오디오 출력 장치 설정 로직 추가
        // 이 부분은 외부 라이브러리나 시스템 설정을 통해 구현해야 합니다.
        Debug.Log("Audio output device changed to: " + audioOutputDeviceDropdown.options[index].text);
    }
    */

    


}

