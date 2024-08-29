using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterCanInvenUI : Singleton<WaterCanInvenUI>
{
    public bool isExist = false;
    public WaterCanData wcd;
    [SerializeField] Image waterBar;
    public GameObject quickItem;
    
    private int maxWater;
    public int MaxWater
    {
        set
        {

        }
    }

    public int curWater;
    public int CurWater
    {
        get { return wcd.CurWater; }
        set
        {
            if(wcd == null)
            {
                wcd = GameManager.Instance.waterCanData;
            }
            waterBar.fillAmount = (float)((float)wcd.CurWater / (float)wcd.MaxWater);
            if(quickItem!=null)
            {
                if(quickItem.activeSelf == true)
                {
                    quickItem.GetComponent<WaterCanQuickUI>().waterBar.fillAmount = (float)((float)wcd.CurWater / (float)wcd.MaxWater);
                }
                
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        wcd = GameManager.Instance.waterCanData;
        curWater = wcd.CurWater;
        maxWater = wcd.MaxWater;
        waterBar.fillAmount = (float)((float)curWater / (float)maxWater);
    }
    


    // Update is called once per frame
    void Update()
    {
        if(wcd !=null)
        {
            //waterBar.fillAmount = (float)((float) wcd.CurWater / (float) wcd.MaxWater);
            //Debug.Log($"{wcd.CurWater}");
            //Debug.Log($"{waterBar.fillAmount}");
        }

        
    }
}
