using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class SeedInvenItem : MonoBehaviour
{
    [SerializeField] Image bgImg;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text countTxt;
    [SerializeField] GameObject countBG;
    [SerializeField] TMP_Text nameTxt;
    [SerializeField] GameObject nameBG;

    private SeedInventory inventory;
    public SeedInvendata data;

    public void SeedSetData (SeedInvendata data)
    {
        this.data = data;
        icon.sprite = data.iconSprite;
        bgImg.sprite = data.bgSprite;
        countTxt.text = $"{data.count}";
        countBG.SetActive(data.count <= 1 ? false : true);
        nameTxt.text = $"{data.title}";
    }

    public void SetSeedInven(SeedInventory inven)
    {
        inventory = inven;
    }

    public void AddData(SeedInvendata data)
    {
        countTxt.text = $"{data.count}";
        countBG.SetActive(data.count <= 1 ? false : true);
    }

    public void OnToggleCheck()
    {
        if(GetComponent<Toggle>().isOn == true)
        {
            inventory.useObj = this;
        }
    }
}
