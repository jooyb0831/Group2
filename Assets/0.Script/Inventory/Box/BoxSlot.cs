using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSlot : MonoBehaviour
{
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
        transform.parent.parent.GetComponent<BoxWindow>().box.Deleteitem(transform.GetChild(0).GetComponent<InvenItem>());
    }
}
