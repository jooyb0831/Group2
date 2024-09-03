using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeSystem
{
    

}
public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private Player p;
    public Player player
    {
        get
        {
            if(p == null)
            {
                p = FindAnyObjectByType<Player>();
            }
            return p;
        }
    }

    /*
    private PlayerData pd;
    public PlayerData playerData
    {
        get
        {
            if(pd==null)
            {
                pd = FindAnyObjectByType<PlayerData>();
            }
            return pd;
        }
    }
    */

    private TimeSystem ts;
    public TimeSystem timeSystem
    {
        get
        {
            if(ts == null)
            {
                ts = FindAnyObjectByType<TimeSystem>();
            }
            return ts;
        }
    }

    private SeedInventory si;
    public SeedInventory seedInventory
    {
        get
        {
            if(si == null)
            {
                si = FindAnyObjectByType<SeedInventory>();
            }
            return si;
        }
    }

    private WaterCanInvenUI waterUI;
    public WaterCanInvenUI waterCanInvenUI
    {
        get
        {
            if(waterUI == null)
            {
                waterUI = FindAnyObjectByType<WaterCanInvenUI>();
            }
            return waterUI;
        }
    }

    private WaterCanData wc;
    public WaterCanData waterCanData
    {
        get
        {
            if (wc == null)
            {
                wc = FindAnyObjectByType<WaterCanData>();
            }

            return wc;
        }
    }

    private PlayerData pd;
    public PlayerData pData
    {
        get
        {
            if (pd == null)
            {
                pd = FindAnyObjectByType<PlayerData>();
            }
            return pd;
        }
    }

    private Inventory inven;
    public Inventory inventory
    {
        get
        {
            if(inven == null)
            {
                inven = FindAnyObjectByType<Inventory>();
            }
            return inven;
        }

    }

    private QuickInventory quickInven;
    public QuickInventory quickInventory
    {
        get
        {
            if(quickInven == null)
            {
                quickInven = FindAnyObjectByType<QuickInventory>();
            }
            return quickInven;
        }
    }

    private InventoryUI invenUI;
    public InventoryUI inventoryUI
    {
        get
        {
            if (invenUI == null)
            {
                invenUI = FindAnyObjectByType<InventoryUI>();
            }
            return invenUI;
        }

    }

    private MoveItem mi;
    public MoveItem moveItem
    {
        get
        {
            if(mi == null)
            {
                mi = FindAnyObjectByType<MoveItem>();
            }
            return mi;
        }
    }

    private ItemGetBG ibg;
    public ItemGetBG itemGetBG
    {
        get
        {
            if(ibg == null)
            {
                ibg = FindAnyObjectByType<ItemGetBG>();
            }
            return ibg;
        }
    }

}
