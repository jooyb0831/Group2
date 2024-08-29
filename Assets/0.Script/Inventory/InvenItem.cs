using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InvenItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] Image bgImg;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text countTxt;
    [SerializeField] GameObject countBG;

    private Inventory inventory;
    private BoxSystem boxSystem;

    public InvenData data;

    public void SetData(InvenData data)
    {
        this.data = data;
        icon.sprite = data.iconSprite;
        bgImg.sprite = data.bgSprite;
        countTxt.text = $"{data.count}";
        countBG.SetActive(data.count <= 1 ? false : true);
    }

    public void AddData(InvenData data)
    {
        countTxt.text = $"{data.count}";
        countBG.SetActive(data.count <= 1 ? false : true);
    }

    public void SetInventory(Inventory inven)
    {
        inventory = inven;
    }

    public void SetBox(BoxSystem box)
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log($"{data.title}, {data.number}π¯, {data.count}∞≥");
        }

        /*
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if(hit.collider == transform)
        {
            
            if (invenOption == null)
            {
                if (Input.GetMouseButton(1))
                {
                    invenOption = Instantiate(itemOptionWindow, transform);
                    invenOption.GetComponent<InvenOption>().item = this;
                    Debug.Log($"{data.title}");
                    invenOption.transform.SetParent(transform.parent.parent.parent);
                    invenOption.transform.SetAsLastSibling();
                }
            }
            else
            {
                return;
            }
        }
        else if(hit.collider!=transform)
        {
            if(invenOption!=null)
            {
                if (Input.GetMouseButton(0))
                {
                    Destroy(invenOption);
                }
            }
            else
            {
                return;
            }
            
        }
        */

    }
    //[SerializeField] BoxUI boxUI;
    public GameObject invenOption = null;
    public GameObject itemOptionWindow;
    public void OnPointerDown(PointerEventData eventData)
    {

        if (Input.GetMouseButtonDown(1))
        {
            if(invenOption==null)
            {
                invenOption = Instantiate(itemOptionWindow, transform);
                if(data.type.Equals(ItemType.Tool))
                {
                    invenOption.GetComponent<ToolInvenOption>().item = this;
                }
                else
                {
                    invenOption.GetComponent<InvenOption>().item = this;
                }
                //Debug.Log($"{data.title}");
                invenOption.transform.SetParent(transform.parent.parent.parent);
                invenOption.transform.SetAsLastSibling();
            }
            else if (invenOption!=null)
            {
                Destroy(invenOption);
                //inventory.ItemMove(true, eventData.position, data);
            }
        }

        else if(Input.GetMouseButton(0))
        {
            if(transform.parent.GetComponent<Slots>()==true||transform.parent.GetComponent<QuickSlots>()==true)
            {
                inventory.ItemMove(true, eventData.position, data);
            }
            
            if(transform.parent.GetComponent<BoxSlot>() == true)
            {
                BoxUI.Instance.ItemMove(true, eventData.position, data);
            }
        }
        

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (data.title.Equals("π∞ª—∏Æ∞≥"))
            {
                transform.GetChild(2).GetComponent<Image>().color = Color.white;
                transform.GetChild(2).GetChild(0).GetComponent<Image>().color = new Color32(61, 196, 233, 255);
            }

            bgImg.color = Color.white;
            icon.color = Color.white;

            if (data.count > 1)
            {
                countBG.SetActive(true);
            }
            if (transform.parent.GetComponent<Slots>() == true || transform.parent.GetComponent<QuickSlots>() == true)
            {
                inventory.PointUp(this);
            }
            if (transform.parent.GetComponent<BoxSlot>() == true)
            {
                Debug.Log("»Æ¿Œµ ");
                BoxUI.Instance.PointUp(this);
            }
        }

        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(Input.GetMouseButton(0))
        {
            if (data.title.Equals("π∞ª—∏Æ∞≥"))
            {
                transform.GetChild(2).GetComponent<Image>().color = Color.clear;
                transform.GetChild(2).GetChild(0).GetComponent<Image>().color = Color.clear;
            }
            bgImg.color = Color.clear;
            icon.color = Color.clear;
            countBG.SetActive(false);

            if(transform.parent.GetComponent<Slots>()==true || transform.parent.GetComponent<QuickSlots>()==true)
            {
                inventory.ItemMove(true, eventData.position);
            }

            if (transform.parent.GetComponent<BoxSlot>() == true)
            {
                Debug.Log("»Æ¿Œ");
                BoxUI.Instance.ItemMove(true, eventData.position);
            }
        }
    }


    public void OnUseItemBtn()
    {
        inventory.UseItem(this);
    }

    void Transparent()
    {
    }

}
