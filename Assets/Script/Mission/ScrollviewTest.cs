using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollviewTest : MonoBehaviour
{
    public GameObject listItemPrefab;
    public Transform contents;

    private void Start()
    {
        var dataManger = DataManager.Instance;

        foreach (var pair in dataManger.dicMissionDatas)
        {
            var go = Instantiate(this.listItemPrefab, contents);

            var listItem = go.GetComponent<UIListItem>();
            var data = pair.Value;
            var info = new MissionInfo(data.id, 0, 0, 0);
            listItem.Init(info);
        }

    }

    private void Update()
    {
        
    }

}
