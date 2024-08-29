using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] FieldItem watercan;
    [SerializeField] FieldItem axe;
    [SerializeField] FieldItem cornSeed;
    [SerializeField] FieldItem carrotSeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Inventory.Instance.GetItem(watercan.GetComponent<FieldItem>().itemData);
            Inventory.Instance.GetItem(cornSeed.GetComponent<FieldItem>().itemData);
            Inventory.Instance.GetItem(carrotSeed.GetComponent<FieldItem>().itemData);
            Inventory.Instance.GetItem(axe.GetComponent<FieldItem>().itemData);
        }
    }
}
