using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instans;

    public GameObject Obj_Chat;

    private void Awake()
    {
        Instans = this;
    }

    public void TalkePanelActive()
    {
        Obj_Chat.SetActive(true);
    }
    public void TalkePanelDestroy()
    {
        Obj_Chat.SetActive(true);

        PlayerPrefs.DeleteAll();
    }



}
