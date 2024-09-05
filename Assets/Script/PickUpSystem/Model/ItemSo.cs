using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory.Model
{
    //������ ������ ���� ��ũ��Ʈ
    [CreateAssetMenu]
    public class ItemSo : ScriptableObject// ���� ������ ������ �����̳ʸ� ����� ���� ���
    {
        // : �ڵ����� �Ӽ��� ������ �� SerializeField

        //�������� ���� ID�� ��ȯ 
        public int ID => GetInstanceID();

        //�������� �̸�
        [field: SerializeField]
        public string Name { get; set; }

        //�������� ����
        [field: SerializeField]
        [field: TextArea]
        public string Description { get; set; }

        //�������� �̹���
        [field: SerializeField]
        public Sprite ItemImage { get; set; }

        //����
        [field: SerializeField]
        public int ItemCoin { get; set; }

        [field: SerializeField]
        public string ItemHp { get; set; }

        [field: SerializeField]
        public string ItemHg { get; set; }





    }
}
