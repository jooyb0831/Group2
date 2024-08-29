using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterCanData : Singleton<WaterCanData>
{
    public GameObject waterLossIcon;
    public GameObject waterCanUI;
    [SerializeField] Image waterBar;
    // 물 한 번 줄 때마다 -7씩 소모.

    private int maxWater;
    public int MaxWater
    {
        get { return maxWater; }
        set
        {
            maxWater = value;
            //WaterCanInvenUI.Instance.maxWater = maxWater;

            if(waterCanUI!=null)
            {
                //waterCanUI.GetComponent<WaterCanInvenUI>().MaxWater = maxWater;
            }
            
            
            
        }
    }

    private int curWater;
    public int CurWater
    {
        get { return curWater; }
        set
        {
            curWater = value;
            //WaterCanInvenUI.Instance.CurWater = curWater;
            
            if(waterCanUI != null)
            {
                waterCanUI.GetComponent<WaterCanInvenUI>().CurWater = curWater;
                return;
            }
            
                
        }
    }

    public bool isEquiped  = false;

    private void Start()
    {
        maxWater = 50;
        curWater = 50;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            CurWater = maxWater;
        }

        //waterBar.fillAmount = (float)((float) CurWater / (float)MaxWater);
        
        if(waterCanUI !=null)
        {
            waterCanUI.GetComponent<WaterCanInvenUI>().wcd = this;
        }
    }


}
