using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;

    private AudioSource bgmSource;

    [Header("Clip")]
    public AudioClip titleClip;
    public AudioClip mainClip;
    public AudioClip bosMapClip;
    public AudioClip endClip;

    [Header("Panel")]
    public GameObject mainPanel;
    public GameObject endPanel;

    private void Awake()
    {
            instance = this;
       
        bgmSource = GetComponent<AudioSource>();
    }

   

    private void Update()
    {
        if (endPanel.activeSelf == true)
        {
            PlayBGM(endClip);
            bgmSource.Stop();
        }
        else if (mainPanel.activeSelf == true)
        {
            PlayBGM(titleClip);
        }
        else if (bgmSource.clip == bosMapClip && mainPanel.activeSelf == false)
        {
            //bosMapClip으로 유지 
            PlayBGM(bosMapClip);
        }
        else
        {
            PlayBGM(mainClip);
        }


       
        
    }

    private void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip != clip)
        {
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }

    public void BosMapBGM()
    {
        PlayBGM(bosMapClip);
    }

}