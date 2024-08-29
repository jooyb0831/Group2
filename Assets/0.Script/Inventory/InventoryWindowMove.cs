using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryWindowMove : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] GameObject inventoryWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector2 downPos;
    public void OnPointerDown(PointerEventData eventData)
    {
        downPos = eventData.position;
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset = eventData.position - downPos;
        downPos = eventData.position;
        inventoryWindow.GetComponent<RectTransform>().anchoredPosition += offset;
    }
}

