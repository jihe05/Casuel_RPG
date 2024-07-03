using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//UI리스트 아이템을 초기화하고 업데이트하는 클래스
public class UIListItem : MonoBehaviour
{

    public Image reward_image;
    public Text reward_amount;
    public Image ImageName;
    public Text textName;
    private MissionInfo info;//미션 정보

    public void Init(MissionInfo info)
    { 
     this.info = info;
      
    
    }

}
