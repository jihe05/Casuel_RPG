using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text tutorialTxtName;
    public Text tutorialTxt;
    
    public string[] names;
    public string[] dialogues;

    public int talkNum;
    private bool skipTyping;
    private Coroutine typingCoroutine;

    public Collider King_Collider;
    public Collider Guide_Collider;

    private void OnEnable()
    {
        StartTalk(dialogues, names);
    }


    //Ÿ���� Text �ڷ�ƾ
    IEnumerator Typing(string talk , string name)
    { 
       tutorialTxt.text = null;
        tutorialTxtName.text = name;
        skipTyping = false;

        for (int i = 0; i < talk.Length; i++)
        {
            if (skipTyping)
            {
                tutorialTxt.text += talk;
                break;
            }
           tutorialTxt.text += talk[i];
           yield return new WaitForSeconds(0.05f);

        }
        
        yield return new WaitForSeconds(1.0f);
        NextTalk();
    }

    //��ȭ ���� 
    public void StartTalk(string[] _talks , string[] name)
    {
        dialogues = _talks;
        names = name;
        gameObject.SetActive(true);
        //ù ��� Ÿ����
        typingCoroutine=StartCoroutine(Typing(dialogues[talkNum] , names[talkNum]));
    }

    //���� ��� ���
    public void NextTalk()
    {
        tutorialTxt.text = null;
        tutorialTxtName.text = null;
        talkNum++;

        if (talkNum == dialogues.Length)
        {
            EndTalk();
            King_Collider.enabled = false;
            return;
        }
        if (talkNum == 2) // �ȳ��ڿ��� ��ȭ�� ������ ����
        {
            EndTalk();
            Guide_Collider.enabled = false;
            return;
        }
        //���� ��� Ÿ����
        typingCoroutine =StartCoroutine(Typing(dialogues[talkNum], names[talkNum]));
    }

    //��ȭ ���� 
    private void EndTalk()
    {
        this.gameObject.SetActive(false);
    }

    public void OnSkipButtonClike()
    {
        SkipTyping();
    }

    public void SkipTyping()
    { 
      if (typingCoroutine != null)
      {
         skipTyping = true;
      }
    }

    

}
