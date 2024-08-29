using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaterCanQuickUI : MonoBehaviour
{
    public Image waterBar;
    public WaterCanData wcd;
    // Start is called before the first frame update
    void Start()
    {
        if(wcd == null)
        {
            wcd = GameManager.Instance.waterCanData;
        }
        waterBar.fillAmount = (float)((float)wcd.CurWater / (float)wcd.MaxWater);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
