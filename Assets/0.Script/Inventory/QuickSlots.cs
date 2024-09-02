using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlots : MonoBehaviour
{
    [SerializeField] public Transform lowSlot;
    public bool isFilled = false;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.childCount == 1)
        {
            isFilled = true;
        }
        else
        {
            isFilled = false;
        }

    }

    public void RemoveItem()
    {
        QuickInventory.Instance.Delete(lowSlot.GetChild(0).GetComponent<QuickInvenItem>());
        lowSlot.GetComponent<QuickSlotsinGame>().isFilled = false;
        //Destroy(slot.GetChild(0).gameObject);
    }
}
