using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotsinGame : MonoBehaviour
{
    public bool isFilled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isFilled == true)
        {
            if (transform.GetChild(0).GetComponent<Toggle>().isOn == true)
            {
                transform.GetChild(0).GetComponent<Image>().color = transform.GetChild(0).GetComponent<Toggle>().colors.selectedColor;
            }
            else
            {
                transform.GetChild(0).GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            return;
        }
        
    }
}
