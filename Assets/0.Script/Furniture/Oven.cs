using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Item
{
    public string itemName;
    public GameObject prefab;
}

public class DragItem : MonoBehaviour, IEndDragHandler
{
    public Item item;
 
    public RectTransform recTrans;
    public CanvasGroup canvas;
    
    public void Awake()
    {
        recTrans = GetComponent<RectTransform>();
        canvas = GetComponent<CanvasGroup>();
    }

    public void OnBeingDrag(PointerEventData eventData)
    {
        canvas.alpha = 0.6f;
        canvas.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        recTrans.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvas.alpha = 1f;
        canvas.blocksRaycasts = true;
    }
}

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragItem draggedItem = eventData.pointerDrag.GetComponent<DragItem>();
        if (draggedItem != null)
        {
            AddItem(draggedItem.item);
            Destroy(draggedItem.gameObject);
        }
    }

    public void AddItem(Item item)
    {

    }

    public Item currentItem;

    public void Drop(PointerEventData eventData)
    {
        DragItem draggedItem = eventData.pointerDrag.GetComponent<DragItem>();
        if (draggedItem != null)
        {
            currentItem = draggedItem.item;
        }
    }
}

public class OvenSlot : MonoBehaviour
{
    public Item[] items;

    [SerializeField] MoveItem moveItem;

    public Item currentItem { get; internal set; }

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


[System.Serializable]
public class Recipe
{
    public Item[] inputItems; //재료 아이템 목록
    public Item outputItem; //완성된 음식
}

public class OvenResult : MonoBehaviour
{
    
}

public class Oven : MonoBehaviour
{
    public Transform ovenPosition;
    public OvenSlot[] ovenInput;
    public OvenSlot ovenOutput;
    public Recipe[] recipes;


    public float Distance = 1f;
    //public Transform player;

    void Start()
    {
        if (ovenPosition == null)
        {
            ovenPosition = GameObject.Find("Oven").transform;
        }
    }

    void Update()
    {
        //if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneChanger.Instance.OpenOven();
                Cook();
            }
        }
    }

    public void Cook()
    {
        //input에 있는 재료들을 확인, 조홥된 결과물을 output에
        foreach (var recipe in recipes)
        {
            if (CheckRecipe(recipe))
            {
                ovenOutput.currentItem = recipe.outputItem;
            }
        }
    }

    private bool CheckRecipe(Recipe recipe)
    {
        //레시피와 슬롯의 아이템이 일치하는지 확인
        for (int i = 0; i < ovenInput.Length; i++)
        {
            if (ovenInput[i].currentItem != recipe.inputItems[i])
            {
                return false;
            }
        }
        return true;
    }

    /*public bool LookingAtObject()
    {
        Vector2 dirToPlayer = player.position - transform.position;
        dirToPlayer.Normalize();

        Ray ray = new Ray(transform.position, dirToPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            return hit.transform == player;
        }

        return false;
    }*/
}
