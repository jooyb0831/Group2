using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInventoryUI : MonoBehaviour
{
    [SerializeField] Transform[] quickSlots;
    [SerializeField] QuickInventory quickInventory;
    // Start is called before the first frame update
    void Start()
    {
        if(quickInventory == null)
        {
            quickInventory = GameManager.Instance.quickInventory;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
