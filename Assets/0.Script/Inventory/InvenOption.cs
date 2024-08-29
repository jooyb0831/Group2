using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenOption : MonoBehaviour
{
    public InvenItem item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         /*
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

       
        if(hit.collider != transform.GetChild(0).GetComponent<BoxCollider2D>())
        {
            
            if(Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
         */
    }

    public void OnUseBtn()
    {
        item.OnUseItemBtn();
        Destroy(gameObject);
    }

    public void OnDumpBtn()
    {
        Inventory.Instance.DumpItem(item);
        Destroy(gameObject);
    }

    public void OnSellBtn()
    {
        Inventory.Instance.SellItem(item);
        Destroy(gameObject);
    }

    public void OnDivideBtn()
    {
        Inventory.Instance.DivideItem(item);
        Destroy(gameObject);
    }
    public void OnExitBtn()
    {
        Destroy(gameObject);
    }
}
