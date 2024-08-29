using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantData
{
    public string PlantTitle { get; set; }
    public float Harvest_Time { get; set; }
    public string SeedTitle { get; set; }
}

public abstract class Farming : MonoBehaviour
{

    public enum State
    {
        Sprout,
        Grass,
        Stem,
        Mature
    }

    [SerializeField] Sprite[] plants;
    [SerializeField] FieldItem fieldItem;
    Transform ground;

    TimeSystem ts;
    SpriteRenderer sr;
    Player p;

    State state = State.Sprout;

    public PlantData data = new PlantData();
    public string seedDataStr;

    private float timer;
    public float Timer
    {
        get { return timer; }
        set 
        {
            timer = value;
            DurationTime = timer;
        }
    }

    public bool isGrown = false;

    // �� Ŭ�� -> ���� �ɾ���(plants[0])


    public virtual void Init()
    {
        state = State.Sprout;
        plantNameTxt.text = data.PlantTitle;
        fullTime = data.Harvest_Time;
        int date = (int)((fullTime - Timer) / 720);
        int hour = (int)(((fullTime - Timer) % 720) / 30);
        int minute = (int)((((((fullTime - Timer) % 720) % 30)) / 5) * 10);
        durationTxt.text = $"{date}�� {hour}�ð� {minute.ToString("#0")}��";
        growBar.fillAmount = (Timer / fullTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        p = GameManager.Instance.player;
        ts = GameManager.Instance.timeSystem;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Grow();
        Harvest();
        //Day();
    }

    void Grow()
    {
        if (isGrown == false)
        {
            if(transform.parent.GetComponent<FarmingGround>().isWatered == true)
            {
                Timer += Time.deltaTime;
            }

            if (Timer >= data.Harvest_Time / 3 && Timer < (data.Harvest_Time / 3) * 2)
            {
                if (sr == null)
                {
                    sr = GetComponent<SpriteRenderer>();
                }
                transform.localPosition = new Vector3(0, 0.1f, 0);
                transform.parent.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<FarmingGround>().originalSprite;
                sr.sprite = plants[1];
                state = State.Grass;
            }

            if (Timer >= (data.Harvest_Time / 3) * 2)
            {
                if (sr == null)
                {
                    sr = GetComponent<SpriteRenderer>();
                }
                transform.localScale = new Vector3(1, 1.2f, 1);
                transform.parent.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<FarmingGround>().originalSprite;
                sr.sprite = plants[2];
                state = State.Stem;
            }

            if (Timer >= data.Harvest_Time)
            {
                if (sr == null)
                {
                    sr = GetComponent<SpriteRenderer>();
                }
                sr.sprite = plants[3];
                transform.parent.GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<FarmingGround>().originalSprite;
                state = State.Mature;
                isGrown = true;
                Timer = 0;
            }
        }
    }

    [SerializeField] GameObject statusWindow;
    
    void Harvest()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if (p == null)
        {
            p = GameManager.Instance.player;
        }
        float dist = Vector2.Distance(transform.position, p.transform.position);

        if(hit.collider == transform.parent.GetComponent<BoxCollider2D>() && dist<2D)
        {
            statusWindow.SetActive(true);
        }
        else
        {
            statusWindow.SetActive(false);
        }

        if (isGrown == false)
        {
            return;
        }

        else
        {
            if(hit.collider == null)
            {
                statusWindow.SetActive(false);
                sr.color = Color.white;
            }

            if (hit.collider == transform.parent.GetComponent<BoxCollider2D>() && dist<2)
            {
                statusWindow.SetActive(true);
                sr.color = new Color32(145, 145, 145, 255);
                if (Input.GetMouseButton(0))
                {
                    if(p.data.SP<3)
                    {
                        Debug.Log("���¹̳ʰ� �����մϴ�.");
                        return;
                    }
                    int rand = Random.Range(3, 5);
                    for (int i = 0; i < rand; i++)
                    {
                        FieldItem I = Instantiate(fieldItem, transform.parent);
                        I.transform.parent = transform.parent;
                        I.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 2, 0);
                    }
                    // �κ��丮 �� �κ��丮 �����Ϳ� ������ �߰�
                    if(p == null)
                    {
                        p = GameManager.Instance.player;
                    }
                    p.Work();
                    transform.parent.GetComponent<FarmingGround>().isPlant = false;
                    Debug.Log($"{data.PlantTitle} {rand}�� ȹ��");
                    Destroy(gameObject);
                }
            }
        }
    }


    private float fullTime;

    [SerializeField] TMP_Text plantNameTxt;
    [SerializeField] TMP_Text durationTxt;
    [SerializeField] Image growBar;

    private float durationTime;
    public float DurationTime
    {
        get { return Timer; }
        set
        {
            if (isGrown == true)
            {
                growBar.fillAmount = 1f;
                durationTxt.text = $"��Ȯ����!";
            }
            else
            {
                int date = (int)((fullTime - Timer) / 720);
                int hour = (int)(((fullTime - Timer) % 720) / 30);
                int minute = (int)((((((fullTime - Timer) % 720) % 30)) / 5) * 10);
                durationTxt.text = $"{date}�� {hour}�ð� {minute.ToString("#0")}��";
                growBar.fillAmount = (Timer / fullTime);
            }

        }
    }
}


