using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickInvenData
{
    public Sprite iconSprite;
    public Sprite bgSprite;
    public int count;
    public string title;
    public ItemType type;
    public InvenItem invenItem;
    public int number;
    public int index;
}
public class QuickInventory : Singleton<QuickInventory>
{
    [SerializeField] QuickInvenItem quickInvenItem;
    [SerializeField] QuickInvenItem quickWaterCanInvenItem;
    public Transform[] quickSlots;
    private Player p;
    public List<QuickInvenItem> quickInvenItems = new List<QuickInvenItem>();
    public List<QuickInvenData> qInvenDatas = new List<QuickInvenData>();
    private List<string> quickInvenItemNameList = new List<string>();
    private int orderNum = 0;
    //List<int> indexNums = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    int x = 0;
    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < quickSlots.Length; i++)
        {
            if (quickSlots[i].GetComponent<QuickSlotsinGame>().isFilled == true)
            {
                indexNums.Add(i);
            }
        }
        */
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if(wheelInput >0)
        {
            x++;
            if (x > 9)
            {
                x = 0;
            }
            SelectItem(x);
           
        }
        else if(wheelInput<0)
        {
            x--;
            if (x < 0)
            {
                x = 9;
            }
            SelectItem(x);
        }

    }

    void SelectItem(int index)
    {
        if(quickSlots[index].GetComponent<QuickSlotsinGame>().isFilled == true)
        {
            quickSlots[index].GetChild(0).GetComponent<Toggle>().isOn = true;

            if(quickSlots[index].GetChild(0).GetComponent<QuickInvenItem>().data.title.Equals("π∞ª—∏Æ∞≥"))
            {
                WaterCanData.Instance.isEquiped = true;
            }
            else
            {
                WaterCanData.Instance.isEquiped = false;
            }
            Debug.Log("º±≈√µ ");
        }
    }

    void ItemEquipCheck()
    {

    }

    
    public void GetItem(InvenItem item, Transform trans)
    {
        if(quickInvenItemNameList.Contains(item.data.title) == false)
        {
            quickInvenItemNameList.Add(item.data.title);
        }
        
        QuickInvenItem quickItem = null;
        if (item.data.type == ItemType.Tool)
        {
            if(item.data.title.Equals("π∞ª—∏Æ∞≥"))
            {
                quickItem = Instantiate(quickWaterCanInvenItem, trans);
                item.GetComponent<WaterCanInvenUI>().quickItem = quickItem.gameObject;
            }
            if(item.data.title.Equals("µµ≥¢"))
            {
                quickItem = Instantiate(quickInvenItem, trans);
            }
        }
        else
        {
            quickItem = Instantiate(quickInvenItem, trans);
        }
       
        QuickInvenData data = new QuickInvenData();
        data.title = item.data.title;
        data.iconSprite = item.data.iconSprite;
        data.bgSprite = item.data.bgSprite;
        data.type = item.data.type;
        data.count = item.data.count;
        data.invenItem = item;
        data.number = orderNum;
        data.index = trans.GetComponent<QuickSlotsinGame>().index;
        quickItem.SetData(data);
        quickItem.SetInventory(this);
        quickInvenItems.Add(quickItem);
        qInvenDatas.Add(data);
        quickItem.GetComponent<Toggle>().group = quickItem.transform.parent.parent.GetComponent<ToggleGroup>();
        quickItem.GetComponent<Toggle>().isOn = false;
        trans.GetComponent<QuickSlotsinGame>().isFilled = true;
        orderNum++;
    }

    void ItemCheck(InvenItem item)
    {
        QuickInvenItem quickItem = null;
        for(int  i = 0; i<quickInvenItems.Count; i++)
        {
            if(quickInvenItems[i].data.title.Equals(item.data.title))
            {
                quickItem = quickInvenItems[i];
                break;
            }
        }
        quickItem.data.count += item.data.count;
        quickItem.GetComponent<QuickInvenItem>().AddData(quickItem.data);
    }

    
    public void ItemCount(QuickInvenItem quickItem, InvenItem invenItem)
    {
        quickItem.data.count = invenItem.data.count;
        quickItem.GetComponent<QuickInvenItem>().AddData(quickItem.data);
    }

    public void Delete(QuickInvenItem quickItem)
    {
        if(quickItem.data.type.Equals(ItemType.Tool))
        {
            if(p == null)
            {
                p = GameManager.Instance.player;
            }
            p.isToolEquiped = false;
            p.toolName = null;
        }

        int chNum = 0;
        for(int i = 0; i<quickInvenItems.Count; i++)
        {
            if(quickInvenItems[i].data.title.Equals(quickItem.data.title))
            {
                chNum++;
            }
        }

        if(chNum<=1)
        {
            for (int i = 0; i < quickInvenItemNameList.Count; i++)
            {
                if (quickInvenItemNameList[i].Equals(quickItem.data.title))
                {
                    quickInvenItemNameList.RemoveAt(i);
                    break;
                }
            }
        }

        for(int i =0; i<quickInvenItems.Count; i++)
        {
            if(quickInvenItems[i].data.number==quickItem.data.number)
            {
                //quickInvenItems[i].data = null;
                quickInvenItems.RemoveAt(i);
                break;
            }
        }

        for(int i =0; i<qInvenDatas.Count; i++)
        {
            if(qInvenDatas[i].number == quickItem.data.number)
            {
                qInvenDatas.RemoveAt(i);
                break;
            }
        }
        Destroy(quickItem.gameObject);
    }

     
    int SlotCheck()
    {
        int index = 0;
        for(int i =0; i<quickSlots.Length; i++)
        {
            if(quickSlots[i].GetComponent<QuickSlotsinGame>().isFilled == false)
            {
                index = i;
                break;
            }
        }
        return index;
}
    public void SetToolItem(InvenItem item)
    {
        QuickInvenItem quickItem = null;
        if (item.data.title.Equals("π∞ª—∏Æ∞≥"))
        {
            quickItem = Instantiate(quickWaterCanInvenItem, quickSlots[SlotCheck()].transform);
            item.GetComponent<WaterCanInvenUI>().quickItem = quickItem.gameObject;
        }
        if (item.data.title.Equals("µµ≥¢"))
        {
            quickItem = Instantiate(quickInvenItem, quickSlots[SlotCheck()].transform);
        }
        
    }

}
