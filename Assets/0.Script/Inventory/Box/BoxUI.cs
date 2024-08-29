using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxUI : Singleton<BoxUI>
{
    public Transform position;
    [SerializeField] GameObject inventory;
    public List <GameObject> boxes;
    public List<GameObject> boxInvenWindow;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoxOpen(int index)
    {
        boxInvenWindow[index].GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 0f);
        inventory.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350f, 0f);
        inventory.SetActive(true);
        boxInvenWindow[index].SetActive(true);
        
    }
    
    public void OnBoxColse(int index)
    {
        boxInvenWindow[index].SetActive(false);
        boxes[index].GetComponent<Box>().isOpen = false;
    }

    public MoveItem moveItem;

    public void ItemMove(bool isShow, Vector3 pos, InvenData data = null)
    {
        if (data != null)
        {
            moveItem.SetData(data);
        }
        moveItem.gameObject.SetActive(isShow);
        moveItem.transform.position = pos;
    }

    public void PointUp(InvenItem invenItem)
    {
        moveItem.MoveSlot(invenItem);
        ItemMove(false, Vector2.zero);

    }
    





}
