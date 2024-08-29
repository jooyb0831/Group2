using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmingGround : Singleton<FarmingGround>
{
    public enum State
    {
        Raw,
        Plant,
        Watered
    }

    public SpriteRenderer sr;
    Player p;
    [SerializeField] public bool isPlant = false;
    [SerializeField] public bool isWatered = false;
    [SerializeField] public Sprite[] plantedTile;
    [SerializeField] Farming[] item;
    private List<string> seedName = new List<string>();
    Color32 wateredColor = new Color32(162, 86, 86, 255);
    Color32 originalColor;
    public Sprite originalSprite;
    State state = State.Raw;

    public virtual void Init()
    {
        sr = GetComponent<SpriteRenderer>();
        state = State.Raw;
        originalColor = sr.color;
        originalSprite = sr.sprite;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(var names in item)
        {
            seedName.Add(names.data.SeedTitle);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
            return;
        }
        Plant();
    }


    GameObject obj;

    [SerializeField] GameObject waterCan;
    //[SerializeField] GameObject statusWindow;
    void Plant()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        float dist = Vector2.Distance(transform.position, p.transform.position);

        if (hit.collider == null)
        {
            if(isWatered == true)
            {
                sr.color = wateredColor;
            }
            else
            {
                sr.color = originalColor;
            }

            return;
        }

        if (hit.collider == transform.GetComponent<BoxCollider2D>() && dist < 1)
        {

            sr.color = new Color32(145, 145, 145, 255);

            if (Input.GetMouseButtonDown(0) && isPlant == false)
            {
                if(isWatered == true)
                {
                    sr.color = wateredColor;
                }
                else
                {
                    sr.color = originalColor;
                }
                if(p == null)
                {
                    p = GameManager.Instance.player;
                }
                if(p.data.SP<3)
                {
                    Debug.Log("스테미너가 부족합니다.");
                    return;
                }
                GameObject window = SeedInventory.Instance.seedInvenWindow;
                Vector2 transformPos = Camera.main.WorldToScreenPoint(transform.position);
                transformPos.y = 750f;
                window.transform.position = transformPos;
                window.SetActive(true);
                window.transform.GetChild(2).gameObject.SetActive(true);
                SeedInventory.Instance.GetPosition(this.gameObject);
            }

            if (Input.GetMouseButtonDown(1) && isWatered == false)
            {
                if (p == null)
                {
                    p = GameManager.Instance.player;
                }
                if(p.data.SP<3)
                {
                    Debug.Log("스태미너가 부족합니다");
                    return;
                }
                if (p.isToolEquiped == true && p.toolName.Equals("물뿌리개"))
                {
                    if (WaterCanData.Instance.CurWater < 7)
                    {
                        GameObject icon = Instantiate(WaterCanData.Instance.waterLossIcon, p.transform);
                        Destroy(icon, 1.5f);
                        return;
                    }
                    else
                    {
                        WaterCanData.Instance.CurWater -= 7;
                        Debug.Log($"현재 물의 양 : {WaterCanData.Instance.CurWater}/{WaterCanData.Instance.MaxWater}");
                        p.Work();
                        StartCoroutine("WaterCanProcess");
                        sr.color = wateredColor;
                        isWatered = true;
                        p.data.SP-=3;
                    }

                }
                else if(p.isToolEquiped == false || p.toolName!="물뿌리개")
                {
                    Debug.Log("물뿌리개가 없습니다.");
                }

            }

        }

    }

    void Water()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        float dist = Vector2.Distance(transform.position, p.transform.position);

        if (hit.collider == null)
        {
            sr.color = Color.white;
            return;
        }

        if (hit.collider == GetComponent<BoxCollider2D>() && dist < 2)
        {
            sr.color = new Color32(145, 145, 145, 255);
        }
    }
    
    IEnumerator WaterCanProcess()
    {
        GameObject obj = Instantiate(waterCan, transform);
        yield return new WaitForSeconds(0.2f);
        obj.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<WateringCan>().waterSprites[1];
        yield return new WaitForSeconds(0.8f);
        obj.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<WateringCan>().waterSprites[0];
        yield return new WaitForSeconds(0.2f);
        Destroy(obj);
    }

    SeedInventory seedInven;
    Farming FindPlant()
    {
        Farming plantItem = null;
        if(seedInven == null)
        {
            seedInven = GameManager.Instance.seedInventory;
        }
        //Debug.Log($"{seedInven.useObj.GetComponent<SeedInvenItem>().data.title}");


        for(int i =0; i<item.Length; i++)
        {

            if(item[i].seedDataStr.Equals(seedInven.useObj.data.title))
            {
                plantItem = item[i];
                Debug.Log($"{item[i].seedDataStr}");
                break;
            }
        }
        return plantItem;
    }

    public void PlantSeed()
    {
        p.Work();
        p.data.SP -= 3;
        Farming plant = FindPlant();
        obj = Instantiate(plant, transform).gameObject;
        sr.sprite = plantedTile[0];
        isPlant = true;
    }
}
