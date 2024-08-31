using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardItem : MonoBehaviour
{
    [SerializeField] FieldItem fish;
    [SerializeField] Transform pos;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text countTxt;

    bool isDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDone==false)
        {
            SetItem();
        }
    }

    public void SetItem()
    {
        fish.itemData.count = 10;
        icon.sprite = fish.itemData.invenIcon;
        countTxt.text =$"{fish.itemData.count}" ;
        Inventory.Instance.GetItem(fish.GetComponent<FieldItem>().itemData);
        isDone = true;
        
    }
}
