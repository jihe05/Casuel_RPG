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


    //타이핑 Text 코루틴
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

    //대화 시작 
    public void StartTalk(string[] _talks , string[] name)
    {
        dialogues = _talks;
        names = name;
        gameObject.SetActive(true);
        //첫 대사 타이핑
        typingCoroutine=StartCoroutine(Typing(dialogues[talkNum] , names[talkNum]));
    }

    //다음 대사 출력
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
        if (talkNum == 2) // 안내자와의 대화가 끝나는 조건
        {
            EndTalk();
            Guide_Collider.enabled = false;
            return;
        }
        //다음 대사 타이핑
        typingCoroutine =StartCoroutine(Typing(dialogues[talkNum], names[talkNum]));
    }

    //대화 종료 
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
