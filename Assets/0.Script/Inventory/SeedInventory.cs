using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedInvendata
{
    public Sprite iconSprite;
    public Sprite bgSprite;
    public int count;
    public string title;
    public ItemType type;
}
public class SeedInventory : Singleton<SeedInventory>
{
    public GameObject seedInvenWindow;
    [SerializeField] SeedInvenItem seedInvenItem;
    [SerializeField] Transform[] seedInvenSlots;
    [SerializeField] Button okBtn;
    private List<SeedInvenItem> seedInvenItems = new List<SeedInvenItem>();
    private List<string> seedInvenItemNameList = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            seedInvenWindow.SetActive(true);
            okBtn.gameObject.SetActive(false);
            foreach(var item in seedInvenItems)
            {
                item.GetComponent<Toggle>().enabled = false;
            }
        }
    }

    public void GetSeed(ItemData itemData)
    {

        if(seedInvenItemNameList.Contains(itemData.itemTitle)==true)
        {
            SeedItemCheck(itemData);
            return;
        }

        seedInvenItemNameList.Add(itemData.itemTitle);
        int index = SlotCheck();
        SeedInvenItem item = Instantiate(seedInvenItem, seedInvenSlots[index]);
        seedInvenSlots[index].GetComponent<Slots>().isFilled = true;
        SeedInvendata data = new SeedInvendata();
        data.title = itemData.itemTitle;
        data.iconSprite = itemData.invenIcon;
        data.bgSprite = itemData.invenBGSprite;
        data.type = itemData.itemType;
        data.count = itemData.count;
        item.SeedSetData(data);
        item.SetSeedInven(this);
        seedInvenItems.Add(item);
        item.GetComponent<Toggle>().group = item.transform.parent.parent.GetComponent<ToggleGroup>();
        item.GetComponent<Toggle>().isOn = false;
    }


    public void GetSeed(InvenItem inItem)
    {

        if (seedInvenItemNameList.Contains(inItem.data.title) == true)
        {
            SeedItemCheck(inItem);
            return;
        }

        seedInvenItemNameList.Add(inItem.data.title);
        int index = SlotCheck();
        SeedInvenItem item = Instantiate(seedInvenItem, seedInvenSlots[index]);
        seedInvenSlots[index].GetComponent<Slots>().isFilled = true;
        SeedInvendata data = new SeedInvendata();
        data.title = inItem.data.title;
        data.iconSprite = inItem.data.iconSprite;
        data.bgSprite = inItem.data.bgSprite;
        data.type = inItem.data.type;
        data.count = inItem.data.count;
        item.SeedSetData(data);
        item.SetSeedInven(this);
        seedInvenItems.Add(item);
        item.GetComponent<Toggle>().group = item.transform.parent.parent.GetComponent<ToggleGroup>();
        item.GetComponent<Toggle>().isOn = false;
    }

    int SlotCheck()
    {
        int number = 0;
        for (int i = 0; i < seedInvenSlots.Length; i++)
        {
            if (seedInvenSlots[i].GetComponent<Slots>().isFilled == false)
            {
                number = i;
                break;
            }
        }
        return number;
    }

    void SeedItemCheck(ItemData itemData)
    {
        SeedInvenItem invenItem = null;

        for(int i=0; i<seedInvenItems.Count; i++)
        {
            if(seedInvenItems[i].data.title.Equals(itemData.itemTitle))
            {
                invenItem = seedInvenItems[i];
                break;
            }
        }
        invenItem.data.count += itemData.count;
        invenItem.GetComponent<SeedInvenItem>().AddData(invenItem.data);
    }

    void SeedItemCheck(InvenItem inItem)
    {
        SeedInvenItem invenItem = null;

        for (int i = 0; i < seedInvenItems.Count; i++)
        {
            if (seedInvenItems[i].data.title.Equals(inItem.data.title))
            {
                invenItem = seedInvenItems[i];
                break;
            }
        }
        invenItem.data.count += inItem.data.count;
        invenItem.GetComponent<SeedInvenItem>().AddData(invenItem.data);
    }


    private GameObject pos = null;

    public SeedInvenItem useObj { get; set; } = null;
    public void OnSelectBtn()
    {
        //Debug.Log($"{useObj.GetComponent<SeedInvenItem>().data.title}");
        pos.GetComponent<FarmingGround>().PlantSeed();
        UseItem(useObj);
        seedInvenWindow.SetActive(false);
    }

    public void GetPosition(GameObject obj)
    {
        pos = obj;
    }

    public void OnExitBtn()
    {
        seedInvenWindow.SetActive(false);
        seedInvenWindow.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        foreach(var item in seedInvenItems)
        {
            item.GetComponent<Toggle>().enabled = true;
        }
    }

    void UseItem(SeedInvenItem useObj)
    {
        useObj.data.count--;

        if(useObj.data.count<=0)
        {
            Inventory.Instance.DeleteSeedItem(useObj);
            DeleteItem(useObj);
            Destroy(useObj.gameObject);
        }
        else
        {
            useObj.GetComponent<SeedInvenItem>().AddData(useObj.data);
            Inventory.Instance.UseSeedItem(useObj);
        }

    }

    
    void DeleteItem(SeedInvenItem seedInven)
    {
        seedInven.transform.parent.GetComponent<Slots>().isFilled = false;
        for (int i = 0; i < seedInvenItemNameList.Count; i++)
        {
            if (seedInvenItemNameList[i].Equals(seedInven.data.title))
            {
                seedInvenItemNameList.RemoveAt(i);
                break;
            }
        }

        for (int i = 0; i < seedInvenItems.Count; i++)
        {
            if (seedInvenItems[i].data.title.Equals(seedInven.data.title))
            {
                //seedInvenItems[i].data = null;
                seedInvenItems.RemoveAt(i);
                break;
            }
        }

    }

    [SerializeField] MoveItem moveItem;
    public void ItemMove(bool isShow, Vector3 pos, SeedInvendata data = null)
    {
        if(data!=null)
        {
            moveItem.SetData(data);
        }
        moveItem.gameObject.SetActive(isShow);
        moveItem.transform.position = pos;
    }

    public void PointUp(SeedInvenItem item)
    {
        moveItem.MoveSeedSlot(item);
        ItemMove(false, Vector2.zero);
    }

    public void FindandDeleteSeedItem(InvenItem inItem)
    {
        SeedInvenItem seedItem = null;

        for(int i = 0; i<seedInvenItemNameList.Count; i++)
        {
            if (seedInvenItems[i].data.title.Equals(inItem.data.title))
            {
                seedItem = seedInvenItems[i];
                break;
            }
        }
        DeleteItem(seedItem);
        Destroy(seedItem.gameObject);

    }
}
