using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDivideWindow : MonoBehaviour
{
    public Transform slot;
    public Button plusBtn;
    public Button minusBtn;
    public TMP_InputField numInputField;

    
    [SerializeField] InvenItem invenItem;
    [SerializeField] int count;
    
    // Start is called before the first frame update
    void Start()
    {
        numInputField.text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject copyItem;
    public void DivideItem(InvenItem item)
    {
        invenItem = item;
        originalCnt = item.data.count;
        copyItem = Instantiate(item.gameObject, slot);
    }

    int originalCnt;
    int inputCnt;

    public void OnInputField()
    {
        if(int.Parse(numInputField.text)>invenItem.data.count)
        {
            Debug.Log("수량이 너무 많습니다.");
            return;
        }
        inputCnt = int.Parse(numInputField.text);
        copyItem.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = $"{originalCnt - inputCnt}";
    }

    public void OnPlusBtn()
    {
        int x = int.Parse(numInputField.text);
        if(x>=invenItem.data.count-1)
        {
            return;
        }
        x += 1;
        numInputField.text = $"{x}";
    }

    public void OnMinusBtn()
    {
        int x = int.Parse(numInputField.text);
        if(x<=1)
        {
            return;
        }
        x -= 1;
        numInputField.text = $"{x}";
    }
    
    public void OnOkBtn()
    {
        invenItem.data.count -= inputCnt;
        invenItem.AddData(invenItem.data);
        if(invenItem.transform.parent.GetComponent<QuickSlots>() == true)
        {
            Transform qs = invenItem.transform.parent.GetComponent<QuickSlots>().slot;
            QuickInventory.Instance.ItemCount(qs.GetChild(0).GetComponent<QuickInvenItem>(), invenItem);
        }
        Inventory.Instance.ItemDivide(invenItem, inputCnt);
        Destroy(gameObject);
    }
}
