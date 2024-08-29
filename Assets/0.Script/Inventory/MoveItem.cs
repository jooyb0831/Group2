using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MoveItem : MonoBehaviour
{
    [SerializeField] Image bgImg;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text countTxt;
    [SerializeField] GameObject countBG;

    public InvenData data;
    public SeedInvendata seedData;
    public Collider2D coll;

    public void SetData(InvenData data)
    {
        this.data = data;
        icon.sprite = data.iconSprite;
        bgImg.sprite = data.bgSprite;
        countTxt.text = $"{data.count}";
        countBG.SetActive(data.count <= 1 ? false : true);
    }


    public void SetItem(InvenItem item)
    {
        this.data = item.data;
        icon.sprite = item.data.iconSprite;
        bgImg.sprite = item.data.bgSprite;
        countTxt.text = $"{item.data.count}";
        countBG.SetActive(item.data.count <= 1 ? false : true);
    }

    public void SetData(SeedInvendata data)
    {
        this.seedData = data;
        icon.sprite = data.iconSprite;
        bgImg.sprite = data.bgSprite;
        countTxt.text = $"{data.count}";
        countBG.SetActive(data.count <= 1 ? false : true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("인식");
        coll = collision;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        coll = null;
    }

    public void QuickSlotSave()
    {
        if (coll != null)
        {
            //
        }
    }

    public void MoveSlot(InvenItem invenItem)
    {
        if (coll.GetComponent<Slots>() == true) // 아이템을 인벤토리의 일반 슬롯으로 이동할 경우
        {
            if (coll.GetComponent<Slots>().isFilled == false)
            {
                if (invenItem.transform.parent.GetComponent<QuickSlots>() == true) // 아이템이 현재 퀵슬롯에 있을 경우
                {
                    invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                    invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                }
                if (invenItem.transform.parent.GetComponent<Slots>() == true) // 아이템이 현재 일반 슬롯에 있을 경우
                {
                    invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                }
                if (invenItem.transform.parent.GetComponent<BoxSlot>() == true) // 아이템을 박스에서 이동할 경우
                {
                    Inventory.Instance.GetBoxItem(invenItem);
                    invenItem.transform.parent.GetComponent<BoxSlot>().isFilled = false;
                    invenItem.transform.parent.GetComponent<BoxSlot>().RemoveItem();
                }

                invenItem.transform.position = coll.transform.position;
                invenItem.transform.SetParent(coll.transform);
                coll.GetComponent<Slots>().isFilled = true;
            }
            
            if (coll.GetComponent<Slots>().isFilled == true)
            {
                if (coll.transform.GetChild(0).GetComponent<InvenItem>().data.title.Equals(invenItem.data.title) && coll.transform.GetChild(0).GetComponent<InvenItem>().data.number != invenItem.data.number)
                {
                    coll.transform.GetChild(0).GetComponent<InvenItem>().data.count += invenItem.data.count;
                    coll.transform.GetChild(0).GetComponent<InvenItem>().AddData(coll.transform.GetChild(0).GetComponent<InvenItem>().data);

                    if (invenItem.transform.parent.GetComponent<QuickSlots>() == true)
                    {
                        invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                        invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                    }
                    if (invenItem.transform.parent.GetComponent<Slots>() == true)
                    {
                        invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                    }
                    if (invenItem.transform.parent.GetComponent<BoxSlot>() == true)
                    {
                        invenItem.transform.parent.GetComponent<BoxSlot>().isFilled = false;
                        invenItem.transform.parent.GetComponent<BoxSlot>().RemoveItem();
                    }
                    Destroy(invenItem.gameObject);
                }
            }
            
        }
        if (coll.GetComponent<QuickSlots>() == true) // 아이템이 퀵슬롯으로 이동할 경우
        {
            if (coll.GetComponent<QuickSlots>().isFilled == false)
            {
                if (invenItem.transform.parent.GetComponent<QuickSlots>() == true) // 아이템이 현재 퀵슬롯에 있을 경우
                {
                    invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                    invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                }
                if (invenItem.transform.parent.GetComponent<Slots>() == true) // 아이템이 현재 일반 슬롯에 있을 경우
                {
                    invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                }
                if (invenItem.transform.parent.GetComponent<BoxSlot>() == true) // 아이템이 박스에서 이동하는 경우
                {
                    Inventory.Instance.GetBoxItem(invenItem);
                    invenItem.transform.parent.GetComponent<BoxSlot>().isFilled = false;
                    invenItem.transform.parent.GetComponent<BoxSlot>().RemoveItem();
                }
                invenItem.transform.position = coll.transform.position;
                invenItem.transform.SetParent(coll.transform);
                coll.GetComponent<QuickSlots>().isFilled = true;
                QuickInventory.Instance.GetItem(invenItem, coll.GetComponent<QuickSlots>().slot);
                //Instantiate(invenItem, coll.GetComponent<QuickSlots>().slot);//
            }

            if(coll.transform.GetComponent<QuickSlots>().isFilled == true)
            {
                if(coll.transform.GetChild(0).GetComponent<InvenItem>().data.title.Equals(invenItem.data.title)&&coll.transform.GetChild(0).GetComponent<InvenItem>().data.number!=invenItem.data.number)
                {
                    coll.transform.GetChild(0).GetComponent<InvenItem>().data.count += invenItem.data.count;
                    coll.transform.GetChild(0).GetComponent<InvenItem>().AddData(coll.transform.GetChild(0).GetComponent<InvenItem>().data);
                    coll.transform.GetComponent<QuickSlots>().slot.GetChild(0).GetComponent<QuickInvenItem>().data.count = coll.transform.GetChild(0).GetComponent<InvenItem>().data.count;
                    coll.transform.GetComponent<QuickSlots>().slot.GetChild(0).GetComponent<QuickInvenItem>().AddData(coll.transform.GetComponent<QuickSlots>().slot.GetChild(0).GetComponent<QuickInvenItem>().data);
                    if (invenItem.transform.parent.GetComponent<QuickSlots>() == true)
                    {
                        invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                        invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                    }

                    if(invenItem.transform.parent.GetComponent<Slots>() == true)
                    {
                        invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                    }

                    if (invenItem.transform.parent.GetComponent<BoxSlot>() == true)
                    {
                        invenItem.transform.parent.GetComponent<BoxSlot>().isFilled = false;
                        invenItem.transform.parent.GetComponent<BoxSlot>().RemoveItem();
                    }
                    Destroy(invenItem.gameObject);
                }
            }


        }
        if (coll.GetComponent<BoxSlot>() == true) // 박스슬롯으로 이동할 경우
        {
            if (coll.GetComponent<BoxSlot>().isFilled == false)
            {
                if (invenItem.transform.parent.GetComponent<QuickSlots>() == true) // 인벤아이템이 퀵슬롯에 있었을 경우
                {
                    invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                    invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                    Inventory.Instance.ToBoxDeleteItem(invenItem); // 인벤토리에서 아이템 삭제
                    coll.transform.parent.parent.GetComponent<BoxWindow>().box.GetComponent<Box>().GetItem(invenItem);
                }
                if (invenItem.transform.parent.GetComponent<Slots>() == true) // 인벤아이템이 일반 인벤슬롯에 있었을 경우
                {
                    invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                    coll.transform.parent.parent.GetComponent<BoxWindow>().box.GetComponent<Box>().GetItem(invenItem);
                    Inventory.Instance.ToBoxDeleteItem(invenItem); // 인벤토리에서 아이템 삭제

                }
                if (invenItem.transform.parent.GetComponent<BoxSlot>() == true) // 인벤아이템이 박스에 있었을 경우
                {
                    invenItem.transform.parent.GetComponent<BoxSlot>().isFilled = false;
                }
                invenItem.transform.position = coll.transform.position;
                invenItem.transform.SetParent(coll.transform);
                coll.GetComponent<BoxSlot>().isFilled = true;

            }

            if (coll.GetComponent<BoxSlot>().isFilled == true)
            {
                if(coll.transform.GetChild(0).GetComponent<InvenItem>().data.title.Equals(invenItem.data.title) &&coll.transform.GetChild(0).GetComponent<InvenItem>().data.number != invenItem.data.number)
                {
                    coll.transform.GetChild(0).GetComponent<InvenItem>().data.count += invenItem.data.count;
                    coll.transform.GetChild(0).GetComponent<InvenItem>().AddData(coll.transform.GetChild(0).GetComponent<InvenItem>().data);
                    if (invenItem.transform.parent.GetComponent<QuickSlots>() == true)
                    {
                        invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                        invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                    }

                    if (invenItem.transform.parent.GetComponent<Slots>() == true)
                    {
                        invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                    }

                    if (invenItem.transform.parent.GetComponent<BoxSlot>() == true)
                    {
                        invenItem.transform.parent.GetComponent<BoxSlot>().isFilled = false;
                        invenItem.transform.parent.GetComponent<BoxSlot>().RemoveItem();
                    }
                    Destroy(invenItem.gameObject);
                }
            }
        }
    }

    public void MoveSeedSlot(SeedInvenItem seedItem)
    {
        if (coll.GetComponent<Slots>() == true && coll.GetComponent<Slots>().isFilled == false)
        {
            seedItem.transform.parent.GetComponent<Slots>().isFilled = false;
            seedItem.transform.position = coll.transform.position;
            seedItem.transform.SetParent(coll.transform);
            coll.GetComponent<Slots>().isFilled = true;
        }
    }
}
