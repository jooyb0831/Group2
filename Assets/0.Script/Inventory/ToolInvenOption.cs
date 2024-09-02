using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolInvenOption : MonoBehaviour
{
    public InvenItem item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSetBtn()
    {
         // �� �κ��丮���� ������ ����ִ°� üũ�ϰ� => ���� ���ʷ� �� �ڸ��� �ֱ� -> �׸��� toggleOn���� ����.

        if(item.transform.parent.GetComponent<QuickSlots>()==true)
        {
            item.transform.parent.GetComponent<QuickSlots>().lowSlot.GetChild(0).GetComponent<Toggle>().isOn = true;
        }
        else
        {
            Inventory.Instance.SetToolItem(item);
        }
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

    public void OnExitBtn()
    {
        Destroy(gameObject);
    }
}
