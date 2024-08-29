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
        Debug.Log("�ν�");
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
        if (coll.GetComponent<Slots>() == true) // �������� �κ��丮�� �Ϲ� �������� �̵��� ���
        {
            if (coll.GetComponent<Slots>().isFilled == false)
            {
                if (invenItem.transform.parent.GetComponent<QuickSlots>() == true) // �������� ���� �����Կ� ���� ���
                {
                    invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                    invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                }
                if (invenItem.transform.parent.GetComponent<Slots>() == true) // �������� ���� �Ϲ� ���Կ� ���� ���
                {
                    invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                }
                if (invenItem.transform.parent.GetComponent<BoxSlot>() == true) // �������� �ڽ����� �̵��� ���
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
        if (coll.GetComponent<QuickSlots>() == true) // �������� ���������� �̵��� ���
        {
            if (coll.GetComponent<QuickSlots>().isFilled == false)
            {
                if (invenItem.transform.parent.GetComponent<QuickSlots>() == true) // �������� ���� �����Կ� ���� ���
                {
                    invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                    invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                }
                if (invenItem.transform.parent.GetComponent<Slots>() == true) // �������� ���� �Ϲ� ���Կ� ���� ���
                {
                    invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                }
                if (invenItem.transform.parent.GetComponent<BoxSlot>() == true) // �������� �ڽ����� �̵��ϴ� ���
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
        if (coll.GetComponent<BoxSlot>() == true) // �ڽ��������� �̵��� ���
        {
            if (coll.GetComponent<BoxSlot>().isFilled == false)
            {
                if (invenItem.transform.parent.GetComponent<QuickSlots>() == true) // �κ��������� �����Կ� �־��� ���
                {
                    invenItem.transform.parent.GetComponent<QuickSlots>().isFilled = false;
                    invenItem.transform.parent.GetComponent<QuickSlots>().RemoveItem();
                    Inventory.Instance.ToBoxDeleteItem(invenItem); // �κ��丮���� ������ ����
                    coll.transform.parent.parent.GetComponent<BoxWindow>().box.GetComponent<Box>().GetItem(invenItem);
                }
                if (invenItem.transform.parent.GetComponent<Slots>() == true) // �κ��������� �Ϲ� �κ����Կ� �־��� ���
                {
                    invenItem.transform.parent.GetComponent<Slots>().isFilled = false;
                    coll.transform.parent.parent.GetComponent<BoxWindow>().box.GetComponent<Box>().GetItem(invenItem);
                    Inventory.Instance.ToBoxDeleteItem(invenItem); // �κ��丮���� ������ ����

                }
                if (invenItem.transform.parent.GetComponent<BoxSlot>() == true) // �κ��������� �ڽ��� �־��� ���
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
