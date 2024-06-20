using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ivnentory.UI
{
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
            itemImage.gameObject.SetActive(false);
            title.text = "";
            description.text = "";

        }

        //설명 참조
        public void SetDescription(Sprite sprite, string itmeName, string itemDescription)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            title.text = itmeName;
            description.text = itemDescription;

        }



    }
}