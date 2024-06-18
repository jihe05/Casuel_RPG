using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDescription : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private Text title;

    [SerializeField]
    private Text description;

    public void Awake()
    {
        ResetDescription();
    }

    //설명 초기화
    public void ResetDescription()
    { 
        this.itemImage.gameObject.SetActive(false);
        this.title.text = "";
        this.description.text = "";

    }

    //설명 참조
    public void SetDescription(Sprite sprite, string itmeName , string itemDescription)
    { 
       this.itemImage.gameObject.SetActive (true);
        this.itemImage.sprite = sprite;
        this.title.text = itmeName;
        this.description.text = itemDescription;
    
    }



}
