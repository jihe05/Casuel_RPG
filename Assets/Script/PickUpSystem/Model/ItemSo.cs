using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory.Model
{
    //아이템 데이터 관리 스크립트
    [CreateAssetMenu]
    public class ItemSo : ScriptableObject// 재사용 가능한 데이터 컨테이너를 만들기 위해 사용
    {
        // : 자동구현 속성을 가지게 된 SerializeField

        //아이템의 고유 ID를 반환 
        public int ID => GetInstanceID();

        //아이템의 이름
        [field: SerializeField]
        public string Name { get; set; }

        //아이템의 설명
        [field: SerializeField]
        [field: TextArea]
        public string Description { get; set; }

        //아이템의 이미지
        [field: SerializeField]
        public Sprite ItemImage { get; set; }

        //가격
        [field: SerializeField]
        public int ItemCoin { get; set; }

        [field: SerializeField]
        public string ItemHp { get; set; }

        [field: SerializeField]
        public string ItemHg { get; set; }





    }
}
