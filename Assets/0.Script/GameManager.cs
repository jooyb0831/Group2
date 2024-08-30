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

    
    
    
}
