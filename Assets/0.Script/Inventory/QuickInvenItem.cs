using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class QuickInvenItem : MonoBehaviour
{
    [SerializeField] Image bgImg;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text countTxt;
    [SerializeField] GameObject countBG;

    private QuickInventory quickInventory;
    public QuickInvenData data;

    public void SetData(QuickInvenData data)
    {
        this.data = data;
        icon.sprite = data.iconSprite;
        bgImg.sprite = data.bgSprite;
        countTxt.text = $"{data.count}";
        countBG.SetActive(data.count <= 1 ? false : true);
    }

    public void AddData(QuickInvenData data)
    {
        countTxt.text = $"{data.count}";
        countBG.SetActive(data.count <= 1 ? false : true);
    }

    public void SetInventory(QuickInventory inven)
    {
        quickInventory = inven;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Player p;
    // Update is called once per frame
    void Update()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
            return;
        }

        if(transform.GetComponent<Toggle>().isOn == true)
        {
            if(this.data.type.Equals(ItemType.Tool))
            {
                p.isToolEquiped = true;
                p.toolName = this.data.title;
            }
        }
        if(transform.GetComponent<Toggle>().isOn == false)
        {
            if(this.data.type.Equals(ItemType.Tool))
            {
                p.isToolEquiped = false;
                p.toolName = null;
            }
        }
        
    }
}
