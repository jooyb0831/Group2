using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] TMP_Text nameTxt;
    [SerializeField] Transform[] slots;
    [SerializeField] Transform[] quickSlots;
    [SerializeField] Transform[] inQuickSlots;
    [SerializeField] Inventory inventory;
    [SerializeField] QuickInventory quickInventory;

    [SerializeField] InvenItem sample;
    [SerializeField] InvenItem waterCanInven;
    [SerializeField] InvenItem axeInvenItem;
    public GameObject inventoryWindow;


    [SerializeField] QuickInvenItem quickInvenItem;
    [SerializeField] QuickInvenItem quickWaterCanInvenItem;
    [SerializeField] MoveItem moveitem;
    [SerializeField] PlayerData pData;
    // Start is called before the first frame update
    void Start()
    {
        if(inventory == null)
        {
            inventory = GameManager.Instance.inventory;
        }
        if (quickInventory == null)
        {
            quickInventory = GameManager.Instance.quickInventory;
        }
        pData = GameManager.Instance.pData;
        inventory.moveItem = moveitem;
        inventory.inventoryWindow = inventoryWindow;
        nameTxt.text = pData.playerName;
        SetInventorySlot();
        SetInventory();
        SetQuickInven();
        InventoryCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(SceneChanger.Instance.screenType!=ScreenType.VampSur || SceneChanger.Instance.screenType!=ScreenType.StagePick)
            {
                inventoryWindow.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                inventoryWindow.SetActive(true);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) && inventoryWindow.activeSelf == true)
        {
            inventoryWindow.SetActive(false);
        }
    }

    void SetInventorySlot()
    {
        for(int i =0; i<slots.Length; i++)
        {
            inventory.invenSlots[i] = slots[i];
        }

        for(int i = 0; i<quickSlots.Length; i++)
        {
            inventory.quickSlots[i] = quickSlots[i];
        }

        for (int i = 0; i < quickSlots.Length; i++)
        {
            quickInventory.quickSlots[i] = inQuickSlots[i];
        }

    }

    //List<InvenItem> items = new List<InvenItem>();
    void SetInventory()
    {
        if(inventory == null)
        {
            inventory = GameManager.Instance.inventory;
        }
        inventory.invenItems.Clear();
        List<InvenData> invenData = inventory.invenDatas;
        if(invenData.Count == 0)
        {
            return;
        }
        for(int i =0; i< invenData.Count; i++)
        {
            SetData(invenData[i]);
        }
    }

    void SetData(InvenData data)
    {
        InvenItem item = null;
        if(data.isQuickSlot == true)
        {
            if (data.title.Equals("¹°»Ñ¸®°³"))
            {
                item = Instantiate(waterCanInven, quickSlots[data.quickIndexNum]);
                item.GetComponent<WaterCanInvenUI>().isExist = true;
                WaterCanData.Instance.waterCanUI = item.gameObject;
            }
            else if (data.title.Equals("µµ³¢"))
            {
                item = Instantiate(axeInvenItem, quickSlots[data.quickIndexNum]);
            }
            else
            {
                item = Instantiate(sample, quickSlots[data.quickIndexNum]);
            }
        }
        else
        {
            if (data.title.Equals("¹°»Ñ¸®°³"))
            {
                item = Instantiate(waterCanInven, slots[data.slotIndexNum]);
                item.GetComponent<WaterCanInvenUI>().isExist = true;
                WaterCanData.Instance.waterCanUI = item.gameObject;
            }
            else if (data.title.Equals("µµ³¢"))
            {
                item = Instantiate(axeInvenItem, slots[data.slotIndexNum]);
            }
            else
            {
                item = Instantiate(sample, slots[data.slotIndexNum]);
            }
        }

        item.SetData(data);
        item.SetInventory(inventory);
        inventory.invenItems.Add(item);

    }

    void SetQuickInven()
    {
        if(quickInventory == null)
        {
            quickInventory = GameManager.Instance.quickInventory;
        }
        quickInventory.quickInvenItems.Clear();
        List<QuickInvenData> quickItems = quickInventory.qInvenDatas;

        if(quickItems.Count == 0)
        {
            return;
        }
        for(int i =0; i<quickItems.Count; i++)
        {
            SetQuickData(quickItems[i]);
        }
    }

    void SetQuickData(QuickInvenData data)
    {
        QuickInvenItem qitem = null;
        if(data.title.Equals("¹°»Ñ¸®°³"))
        {
            qitem = Instantiate(quickWaterCanInvenItem, inQuickSlots[data.index]);
            InvenItem item = FindInvenItem();
            item.GetComponent<WaterCanInvenUI>().quickItem = qitem.gameObject;
        }
        else
        {
            qitem = Instantiate(quickInvenItem, inQuickSlots[data.index]);
        }
        qitem.SetData(data);
        qitem.SetInventory(quickInventory);
        qitem.GetComponent<Toggle>().group = qitem.transform.parent.parent.GetComponent<ToggleGroup>();
        qitem.GetComponent<Toggle>().isOn = false;
        quickInventory.quickInvenItems.Add(qitem);

    }

    InvenItem FindInvenItem()
    {
        InvenItem item = null;
        for(int i =0; i<inventory.invenDatas.Count; i++)
        {
            if(inventory.invenItems[i].data.title.Equals("¹°»Ñ¸®°³"))
            {
                item = inventory.invenItems[i];
            }
        }
        return item;
    }

    void InventoryCheck()
    {
        foreach(var item in slots)
        {
            if(item.childCount>=1)
            {
                item.GetComponent<Slots>().isFilled = true;
            }
        }

        foreach(var item in quickSlots)
        {
            if (item.childCount >= 1)
            {
                item.GetComponent<QuickSlots>().isFilled = true;
                item.GetComponent<QuickSlots>().lowSlot.GetComponent<QuickSlotsinGame>().isFilled = true;
            }
        }
    }
}
