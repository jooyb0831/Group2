using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoxData
{
    public int boxIndex;
    public string boxTitle;
    public List<InvenItem> boxItemList;
}
public abstract class BoxSystem : Singleton<BoxSystem>
{
    public BoxData boxData;
    [SerializeField] List<Sprite> boxSprites;

    public bool isOpen;
    private Player p;

    protected SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        p = GameManager.Instance.player;

    }

    public virtual void Init()
    {
        isOpen = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (p == null)
        {
            p = GameManager.Instance.player;
            return;
        }
        OpenBox();

        if (isOpen == true)
        {
            sr.sprite = boxSprites[1];
        }
        else
        {
            sr.sprite = boxSprites[0];
        }
    }

    void OpenBox()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        float dist = Vector2.Distance(transform.position, p.transform.position);
        if (hit.collider == null)
        {
            return;
        }

        if (hit.collider == transform.GetComponent<BoxCollider2D>() && dist < 2)
        {
            //Debug.Log(" ÀÎ½Ä");
            if (Input.GetMouseButtonDown(0) && isOpen == false)
            {
                isOpen = true;
                BoxUI.Instance.BoxOpen(boxData.boxIndex);
                Debug.Log($"{boxData.boxIndex}");
            }
        }
    }

    /*
    public virtual void GetItem(InvenItem item)
    {

    }

    public virtual void Deleteitem(InvenItem item)
    {
   
    }
    */
}