using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//UI����Ʈ �������� �ʱ�ȭ�ϰ� ������Ʈ�ϴ� Ŭ����
public class UIListItem : MonoBehaviour
{

    public Image reward_image;
    public Text reward_amount;
    public Image ImageName;
    public Text textName;
    private MissionInfo info;//�̼� ����

    public void Init(MissionInfo info)
    { 
     this.info = info;
      
    
    }

}
