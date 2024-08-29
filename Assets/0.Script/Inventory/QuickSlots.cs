using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlots : MonoBehaviour
{
    [SerializeField] public Transform slot;
    public bool isFilled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RemoveItem()
    {
        QuickInventory.Instance.Delete(slot.GetChild(0).GetComponent<QuickInvenItem>());
        slot.GetComponent<QuickSlotsinGame>().isFilled = false;
        //Destroy(slot.GetChild(0).gameObject);
    }
}
