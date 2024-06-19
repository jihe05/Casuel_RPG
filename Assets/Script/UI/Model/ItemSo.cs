using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ������ ���� ��ũ��Ʈ
[CreateAssetMenu]
public class ItemSo : ScriptableObject// ���� ������ ������ �����̳ʸ� ����� ���� ���
{
    // : �ڵ����� �Ӽ��� ������ �� SerializeField
    //������ ���� ���� ����
    [field: SerializeField]
    public bool IsStackable {get; set;}

    //�������� ���� ID�� ��ȯ 
    public int ID => GetInstanceID();

    //�������� �ִ� ũ��
    [field: SerializeField]
    public int MaxStackSize { get; set; } = 1;

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


}
