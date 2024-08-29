using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSellWindow : MonoBehaviour
{
    public Transform slot;
    public Button plusBtn;
    public Button minusBtn;
    public TMP_InputField numInputField;
    public TMP_Text totlaPriceTxt;
    
    private Player p;
    [SerializeField] InvenItem invenItem;
    [SerializeField] int price;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellItem(InvenItem item)
    {
        invenItem = item;
        Debug.Log($"{item.data.price}");
        Instantiate(item.gameObject, slot);
        price = item.data.price;

    }

    [SerializeField] int totalPrice;
    public void OnInputField()
    {
        Debug.Log($"{numInputField.text}");
        string numStr = numInputField.text;
        int x = int.Parse(numStr);
        totalPrice = x * price;
        totlaPriceTxt.text = $"{totalPrice}";
        Debug.Log($"���� : {x}");
        Debug.Log($"���� : {price}");
    }

    
    public void OnSellBtn()
    {
        if(int.Parse(numInputField.text)>invenItem.data.count)
        {
            Debug.Log("������ �ʹ� �����ϴ�.");
            return;
        }
        if(p == null)
        {
            p = GameManager.Instance.player;
        }
        Inventory.Instance.ItemCount(invenItem, int.Parse(numInputField.text));
        p.data.Gold += totalPrice;
        Destroy(gameObject);
    }

    public void OnPlusBtn()
    {
        int x = int.Parse(numInputField.text);
        if (x >= invenItem.data.count)
        {
            return;
        }
        x += 1;
        numInputField.text = $"{x}";
    }

    public void OnMinusBtn()
    {
        int x = int.Parse(numInputField.text);
        if (x <= 0)
        {
            return;
        }
        x -= 1;
        numInputField.text = $"{x}";
    }

    public void OnValueChange()
    {
        string numStr = numInputField.text;
        int x = int.Parse(numStr);
        totalPrice = x * price;
        totlaPriceTxt.text = $"{totalPrice}";
    }
}
