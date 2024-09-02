using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InvenData
{
    public Sprite iconSprite;
    public Sprite bgSprite;
    public int count;
    public string title;
    public ItemType type;
    public int plusEnergy;
    public int price;
    public int number;
    public int slotIndexNum;
    public bool isQuickSlot;
    public int quickIndexNum;
}
public enum ItemType
{
    Tool,
    Seed,
    Plant,
    Wood,
    Food,
    Etc
}
public class InventoryData
{
    public List<InvenItem> items = new List<InvenItem>();
}
public class Inventory : Singleton<Inventory>
{
    [SerializeField] InvenItem invenItem;
    [SerializeField] InvenItem waterCanInvenItem;
    [SerializeField] InvenItem axeInvenItem;
    public Transform[] invenSlots;
    public Transform[] quickSlots;

    public InventoryData inventoryData = new InventoryData();

    public List<InvenItem> invenItems = new List<InvenItem>();  // 인벤토리 데이터 받는 리스트.
    private List<string> invenItemNameList = new List<string>();
    public List<InvenData> invenDatas = new List<InvenData>();

    private Player p;

    public int orderNum = 0;
    //private Dictionary<ItemType, string[]> randDic = new Dictionary<ItemType, string[]>();
    // Key : ItemType, value : string[]
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            foreach (var item in invenItems)
            {
                Debug.Log($"{item.GetComponent<InvenItem>().data.title}");
            }
        }
    }

    public void GetItem(ItemData itemData)
    {
        if (itemData.itemType == ItemType.Seed)
        {
            SeedInventory.Instance.GetSeed(itemData);
            //return;
        }

        if (invenItemNameList.Contains(itemData.itemTitle) == true)
        {
            ItemCheck(itemData);
            return;
        }

        invenItemNameList.Add(itemData.itemTitle);
        int index = -1;
        InvenItem item = null;
        if (itemData.itemType == ItemType.Tool)
        {
            if (itemData.itemTitle.Equals("물뿌리개"))
            {
                index = SlotCheck();
                item = Instantiate(waterCanInvenItem, invenSlots[index]);
                item.GetComponent<WaterCanInvenUI>().isExist = true;
                WaterCanData.Instance.waterCanUI = item.gameObject;

            }
            if (itemData.itemTitle.Equals("도끼"))
            {
                index = SlotCheck();
                item = Instantiate(axeInvenItem, invenSlots[index]);
            }
        }
        else
        {
            index = SlotCheck();
            item = Instantiate(invenItem, invenSlots[index]);
        }

        invenSlots[index].GetComponent<Slots>().isFilled = true;
        InvenData data = new InvenData();
        data.title = itemData.itemTitle;
        data.iconSprite = itemData.invenIcon;
        data.bgSprite = itemData.invenBGSprite;
        data.type = itemData.itemType;
        data.count = itemData.count;
        data.plusEnergy = itemData.plusEnergy;
        data.price = itemData.price;
        data.number = orderNum;
        data.slotIndexNum = index;
        data.isQuickSlot = false;
        item.SetData(data);
        item.SetInventory(this);
        invenItems.Add(item);
        invenDatas.Add(item.data);
        inventoryData.items.Add(item);
        orderNum++;
    }

    int SlotCheck()
    {
        int number = 0;
        for (int i = 0; i < invenSlots.Length; i++)
        {
            if (invenSlots[i].GetComponent<Slots>().isFilled == false)
            {
                number = i;
                break;
            }
        }
        return number;
    }


    void ItemCheck(ItemData itemData)
    {
        InvenItem invenItem = null;

        for (int i = 0; i < invenItems.Count; i++)
        {
            if (invenItems[i].data.title.Equals(itemData.itemTitle))
            {
                invenItem = invenItems[i];
                break;
            }
        }
        invenItem.data.count += itemData.count;
        invenItem.GetComponent<InvenItem>().AddData(invenItem.data);

        if (invenItem.transform.parent.GetComponent<QuickSlots>() == true)
        {
            Transform qs = invenItem.transform.parent.GetComponent<QuickSlots>().lowSlot;
            QuickInventory.Instance.ItemCount(qs.GetChild(0).GetComponent<QuickInvenItem>(), invenItem);
            //qs.GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = $"{invenItem.data.count}";
        }
    }

    void ItemCheck(InvenItem item)
    {
        InvenItem invenItem = null;

        for (int i = 0; i < invenItems.Count; i++)
        {
            if (invenItems[i].data.title == item.data.title)
            {
                invenItem = invenItems[i];
                break;
            }
        }
        invenItem.data.count += item.data.count;
        invenItem.GetComponent<InvenItem>().AddData(invenItem.data);

        if (invenItem.transform.parent.GetComponent<QuickSlots>() == true)
        {
            Transform qs = invenItem.transform.parent.GetComponent<QuickSlots>().lowSlot;
            QuickInventory.Instance.ItemCount(qs.GetChild(0).GetComponent<QuickInvenItem>(), invenItem);
            //qs.GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = $"{invenItem.data.count}";
        }
    }

    public MoveItem moveItem;
    public void ItemMove(bool isShow, Vector3 pos, InvenData data = null)
    {
        if (data != null)
        {
            moveItem.SetData(data);
        }
        moveItem.gameObject.SetActive(isShow);
        moveItem.transform.position = pos;
    }

    public void PointUp(InvenItem invenItem)
    {
        moveItem.MoveSlot(invenItem);
        ItemMove(false, Vector2.zero);

    }

    public void UseItem(InvenItem item) // 아이템 사용하는 코드
    {
        if (item.data.type.Equals(ItemType.Plant))
        {
            if (p == null)
            {
                p = GameManager.Instance.player;
            }
            if (p.data.SP == p.data.MAXSP)
            {
                Debug.Log("스태미너가 가득 찼습니다.");
                return;
            }
            else
            {
                p.data.SP += item.data.plusEnergy;
            }
        }
        item.data.count--;

        if (item.data.count <= 0)
        {
            if (item.transform.parent.GetComponent<QuickSlots>() == true)
            {
                item.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetComponent<QuickSlotsinGame>().isFilled = false;
                QuickInventory.Instance.Delete(item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetChild(0).GetComponent<QuickInvenItem>());
            }
            DeleteItem(item);
            Destroy(item.gameObject);
        }
        else
        {
            item.GetComponent<InvenItem>().AddData(item.data);

            if (item.transform.parent.GetComponent<QuickSlots>() == true)
            {
                Transform qs = item.transform.parent.GetComponent<QuickSlots>().lowSlot;
                QuickInventory.Instance.ItemCount(qs.GetChild(0).GetComponent<QuickInvenItem>(), item);

                //qs.GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = $"{item.data.count}";
            }
        }
    }

    public void DumpItem(InvenItem item) // 아이템 버리는 코드
    {
        item.data.count--;
        if (item.data.count <= 0)
        {
            if (item.transform.parent.GetComponent<QuickSlots>() == true)
            {
                item.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                QuickInventory.Instance.Delete(item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetChild(0).GetComponent<QuickInvenItem>());
            }
            DeleteItem(item);
            Destroy(item.gameObject);
        }
        else
        {
            item.GetComponent<InvenItem>().AddData(item.data);

            if (item.transform.parent.GetComponent<QuickSlots>() == true)
            {
                Transform qs = item.transform.parent.GetComponent<QuickSlots>().lowSlot;
                QuickInventory.Instance.ItemCount(qs.GetChild(0).GetComponent<QuickInvenItem>(), item);

                //qs.GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = $"{item.data.count}";
            }
        }
    }

    public void DeleteItem(InvenItem item) // 아이템 삭제하는 코드
    {
        if (item.transform.parent.GetComponent<QuickSlots>() == true)
        {
            item.transform.parent.GetComponent<QuickSlots>().isFilled = false;
            item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetComponent<QuickSlotsinGame>().isFilled = false;
            QuickInventory.Instance.Delete(item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetChild(0).GetComponent<QuickInvenItem>());
        }
        if (item.transform.parent.GetComponent<Slots>() == true)
        {
            item.transform.parent.GetComponent<Slots>().isFilled = false;
        }
        item.GetComponent<InvenItem>().invenOption = null;
       
        // 아이템 묶음이 두 개 이상 있는지 체크하기
        int chNum = 0;
        for (int i = 0; i < invenItems.Count; i++)
        {
            if (invenItems[i].data.title.Equals(item.data.title))
            {
                chNum++;
            }
        }

        if (chNum <= 1)
        {
            for (int i = 0; i < invenItemNameList.Count; i++)
            {
                if (invenItemNameList[i].Equals(item.data.title))
                {
                    invenItemNameList.RemoveAt(i);
                    break;
                }
            }
        }

        for (int i = 0; i < invenItems.Count; i++)
        {
            if (invenItems[i].data.number.Equals(item.data.number))
            {
                //invenItems[i].data = null;
                invenItems.RemoveAt(i);
                break;
            }
        }

        for (int i = 0; i < inventoryData.items.Count; i++)
        {
            if (inventoryData.items[i].data.number.Equals(item.data.number))
            {
                //invenItems[i].data = null;
                inventoryData.items.RemoveAt(i);
                break;
            }
        }

        for(int i = 0; i< invenDatas.Count; i++)
        {
            if(invenDatas[i].number == item.data.number)
            {
                invenDatas.RemoveAt(i);
                break;
            }
        }
    }

    public void ToBoxDeleteItem(InvenItem item) // 아이템 박스로 옮기는 코드
    {
        if(item.data.type.Equals(ItemType. Seed))
        {
            SeedInventory.Instance.FindandDeleteSeedItem(item);
        }
        if (item.transform.parent.GetComponent<QuickSlots>() == true)
        {
            item.transform.parent.GetComponent<QuickSlots>().isFilled = false;
        }
        if (item.transform.parent.GetComponent<Slots>() == true)
        {
            item.transform.parent.GetComponent<Slots>().isFilled = false;
        }
        item.GetComponent<InvenItem>().invenOption = null;

        // 아이템 묶음이 두 개 이상 있는지 체크하기
        int chNum = 0;
        for (int i = 0; i < invenItems.Count; i++)
        {
            if (invenItems[i].data.title.Equals(item.data.title))
            {
                chNum++;
            }
        }

        if (chNum <= 1)
        {
            for (int i = 0; i < invenItemNameList.Count; i++)
            {
                if (invenItemNameList[i].Equals(item.data.title))
                {
                    invenItemNameList.RemoveAt(i);
                    break;
                }
            }
        }

        for (int i = 0; i < invenItems.Count; i++)
        {
            if (invenItems[i].data.number.Equals(item.data.number))
            {
                //invenItems[i].data = null;
                invenItems.RemoveAt(i);
                break;
            }
        }
    }
    
    [SerializeField] GameObject sellItemWindow;
    public void SellItem(InvenItem item)
    {
        if(item.data.count<=1)
        {
            if(p==null)
            {
                p = GameManager.Instance.player;
            }
            p.data.Gold += item.data.price;
            DeleteItem(item);
            Destroy(item.gameObject);
        }
        else
        {
            GameObject window = Instantiate(sellItemWindow, InventoryUI.Instance.inventoryWindow.transform);
            window.GetComponent<ItemSellWindow>().SellItem(item);
        }
        /*
        Instantiate(item.gameObject, window.GetComponent<ItemSellWindow>().slot);
        window.GetComponent<ItemSellWindow>().numInputField.text = "1";
        window.GetComponent<ItemSellWindow>().totlaPriceTxt.text = $"{(item.data.price) * int.Parse((window.GetComponent<ItemSellWindow>().numInputField.text))}";
        */
    }

    [SerializeField] GameObject divideItemWindow;
    public void DivideItem(InvenItem item)
    {
        GameObject window = Instantiate(divideItemWindow, InventoryUI.Instance.inventoryWindow.transform);
        window.GetComponent<ItemDivideWindow>().DivideItem(item);
    }

    public void ItemCount(InvenItem item, int count)
    {
        int minus = item.data.count - count;

        if(minus <= 0)
        {
            DeleteItem(item);
            Destroy(item.gameObject);
        }
        else
        {
            item.data.count -= count;
            item.GetComponent<InvenItem>().AddData(item.data);
        }
    }

    public void UseSeedItem(SeedInvenItem seedItem)
    {
        InvenItem item = null;
        for(int i = 0; i< invenItems.Count; i++)
        {
            if(invenItems[i].data.title.Equals(seedItem.data.title))
            {
                item = invenItems[i];
                break;
            }
        }

        item.data.count = seedItem.data.count;
        item.AddData(item.data);
    }

    public void DeleteSeedItem(SeedInvenItem seedItem)
    {
        InvenItem item = null;
        for (int i = 0; i < invenItems.Count; i++)
        {
            if (invenItems[i].data.title.Equals(seedItem.data.title))
            {
                item = invenItems[i];
                break;
            }
        }
        if(item.transform.parent.GetComponent<QuickSlots>()==true)
        {
            item.transform.parent.GetComponent<QuickSlots>().isFilled = false;
            item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetComponent<QuickSlotsinGame>().isFilled = false;
            QuickInventory.Instance.Delete(item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetChild(0).GetComponent<QuickInvenItem>());
        }
        DeleteItem(item);
        Destroy(item.gameObject);
    }

    public void GetItem(InvenItem inItem)
    {
        if (inItem.data.type == ItemType.Seed)
        {
            SeedInventory.Instance.GetSeed(inItem);
            //return;
        }

        if (invenItemNameList.Contains(inItem.data.title) == true)
        {
            ItemCheck(inItem);
            return;
        }

        invenItemNameList.Add(inItem.data.title);
        int index = -1;
        InvenItem item = null;
        if (inItem.data.type == ItemType.Tool)
        {
            if (inItem.data.title.Equals("물뿌리개"))
            {
                index = SlotCheck();
                item = Instantiate(waterCanInvenItem, invenSlots[index]);
                item.GetComponent<WaterCanInvenUI>().isExist = true;
                WaterCanData.Instance.waterCanUI = item.gameObject;

            }
            if (inItem.data.title.Equals("도끼"))
            {
                index = SlotCheck();
                item = Instantiate(axeInvenItem, invenSlots[index]);
            }
        }
        else
        {
            index = SlotCheck();
            item = Instantiate(invenItem, invenSlots[index]);
        }

        invenSlots[index].GetComponent<Slots>().isFilled = true;
        InvenData data = new InvenData();
        data.title = inItem.data.title;
        data.iconSprite = inItem.data.iconSprite;
        data.bgSprite = inItem.data.bgSprite;
        data.type = inItem.data.type;
        data.count = inItem.data.count;
        data.plusEnergy = inItem.data.plusEnergy;
        data.price = inItem.data.price;
        data.number = orderNum;
        data.slotIndexNum = index;
        data.isQuickSlot = false;
        item.SetData(data);
        item.SetInventory(this);
        invenItems.Add(item);
        inventoryData.items.Add(item);
        orderNum++;
    }

    public void GetBoxItem(InvenItem inItem)
    {
        if(inItem.data.type.Equals(ItemType.Seed))
        {
            SeedInventory.Instance.GetSeed(inItem);
        }
        if (invenItemNameList.Contains(inItem.data.title) == true)
        {
            return;
        }
        invenItemNameList.Add(inItem.data.title);
        invenItems.Add(inItem);

    }


    public void ItemDivide(InvenItem inItem, int cnt)
    {
        int index = SlotCheck();
        InvenItem newItem = Instantiate(invenItem, invenSlots[index]);

        InvenData data = new InvenData();
        data.title = inItem.data.title;
        data.iconSprite = inItem.data.iconSprite;
        data.bgSprite = inItem.data.bgSprite;
        data.type = inItem.data.type;
        data.count = cnt;
        data.plusEnergy = inItem.data.plusEnergy;
        data.price = inItem.data.price;
        data.number = orderNum;
        newItem.SetData(data);
        newItem.SetInventory(this);
        orderNum++;
    }

    int QuickSlotCheck()
    {
        int index = 0;
        for(int i = 0; i<quickSlots.Length; i++)
        {
            if(quickSlots[i].GetComponent<QuickSlots>().isFilled == false)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public void SetToolItem(InvenItem item)
    {
        QuickInventory.Instance.GetItem(item, quickSlots[QuickSlotCheck()].GetComponent<QuickSlots>().lowSlot);
        item.transform.parent.GetComponent<Slots>().isFilled = false;
        item.transform.position = quickSlots[QuickSlotCheck()].transform.position;
        item.transform.SetParent(quickSlots[QuickSlotCheck()].transform);
        item.transform.parent.GetComponent<QuickSlots>().isFilled = true;
        item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetChild(0).GetComponent<Toggle>().isOn = true;
    }
}

    
