using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetBG : MonoBehaviour
{
    private Inventory inventory;
    public List<ItemGet> itemGets;
    public List<string> itemTitles;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameManager.Instance.inventory;
        inventory.itemgetBG = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
