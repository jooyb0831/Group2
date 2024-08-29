using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : BoxSystem
{
    [SerializeField] protected List<InvenItem> boxItemList;
    [SerializeField] protected List<string> boxItemNameList;
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        sr = GetComponent<SpriteRenderer>();

        base.Init();
    }

    public void GetItem(InvenItem item)
    {
        if (boxItemNameList.Contains(item.data.title) == true)
        {
            return;
        }
        else
        {
            boxItemNameList.Add(item.data.title);
            boxItemList.Add(item);
            boxData.boxItemList.Add(item);
        }
    }

    public void Deleteitem(InvenItem item)
    {
        for (int i = 0; i < boxItemNameList.Count; i++)
        {
            if (boxItemNameList[i].Equals(item.data.title))
            {
                boxItemNameList.RemoveAt(i);
                break;
            }
        }

        for (int i = 0; i < boxItemList.Count; i++)
        {
            if (boxItemList[i].data.title.Equals(item.data.title))
            {
                boxItemList.RemoveAt(i);
                break;
            }
        }

        for (int i = 0; i < boxData.boxItemList.Count; i++)
        {
            if (boxData.boxItemList[i].data.title.Equals(item.data.title))
            {
                boxData.boxItemList.RemoveAt(i);
                break;
            }
        }

    }

}
