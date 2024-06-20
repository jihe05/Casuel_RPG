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

        //���� �ʱ�ȭ
        public void ResetDescription()
        {
            itemImage.gameObject.SetActive(false);
            title.text = "";
            description.text = "";

        }

        //���� ����
        public void SetDescription(Sprite sprite, string itmeName, string itemDescription)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            title.text = itmeName;
            description.text = itemDescription;

        }



    }
}