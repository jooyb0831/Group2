using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    private int year =1;
    public int Year
    {
        get { return year; }
        set
        {
            year = value;
            GameUI.Instance.Year = year;
        }
    }

    private int month =1;
    public int Month 
    { 
        get { return month; }
        set
        {
            month = value;
            GameUI.Instance.Month = month;
        }      
    }

    private int date=1;
    public int Date 
    {
        get { return date; }
        set
        {
            date = value;
            GameUI.Instance.Date = date;
        }
    }

    private int minute=0;
    public int Minute 
    {
        get { return minute; }
        set
        {
            minute = value;
            if(SceneChanger.Instance.screenType.Equals(ScreenType.VampSur) || SceneChanger.Instance.screenType.Equals(ScreenType.StagePick))
            {
                return;
            }
            GameUI.Instance.Minute = minute;
        }
    }

    private int hour=6;
    public int Hour
    {
        get { return hour; }
        set
        {
            hour = value;
            if (SceneChanger.Instance.screenType.Equals(ScreenType.VampSur) || SceneChanger.Instance.screenType.Equals(ScreenType.StagePick))
            {
                return;
            }
            GameUI.Instance.Hour = hour;
        }
    }
    // 실제 5초 -> 인게임 10분.
    // 하루 구성 : 오전 6시 ~ 오전 2시, 오후 6시부터는 밤으로 판단

    [SerializeField] private float timer;
    private float realTimer = 5f;
    public int today=1;
    public float sumTimer;

    // Start is called before the first frame update
    private void Awake()
    {
        var obj = FindObjectsOfType<TimeSystem>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        today = Date;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
        DateCount();

        sumTimer += Time.deltaTime;
        if(sumTimer>=720f)
        {
            sumTimer = 0;
            today++;
        }
    }

    void TimeCount()
    {
        timer += Time.deltaTime;

        if (timer >= realTimer)
        {
            timer = 0;
            Minute += 10;
            if (Minute == 60)
            {
                Hour += 1;
                Minute = 0;
                if (Hour == 24)
                {
                    Hour = 0;
                    Date += 1;
                }
                if (Hour == 2)
                {
                    DayOver();
                }
            }
        }
    }

    void DayOver()
    {
        Hour = 6;
        Minute = 0;
        sumTimer = 720f;
        Debug.Log($"{today}일째");
        ResetGround();
    }

    void DateCount()
    {
        if(Input.GetKeyDown(KeyCode.F3))
        {
            Sleep();
        }
        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
        {
            if (Date == 32)
            {
                Month += 1;
                Date = 1;
                if (Month >= 13)
                {
                    Month = 1;
                    Year += 1;
                }
            }
        }
        else if (Month == 2)
        {
            if (Date == 29)
            {
                Month += 1;
                Date = 1;
            }
        }
        else
        {
            if (Date == 31)
            {
                Month += 1;
                Date = 1;
            }
        }
    }

    void Sleep()
    {
        if(Hour>=6 && Hour<=23)
        {
            Date += 1;
        }
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Plant");
        foreach(var item in obj)
        {
            if(item.transform.parent.GetComponent<FarmingGround>().isWatered == true)
            {
                item.GetComponent<Farming>().Timer += 720 - sumTimer;
            }
            
        }
        Hour = 6;
        Minute = 0;
        today++;
        Debug.Log($"{today}일째");
        timer = 0;
        sumTimer = 0;
        ResetGround();
    }


    void ResetGround()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("FarmGround");

        foreach(var item in obj)
        {
            item.GetComponent<FarmingGround>().isWatered = false;
            item.GetComponent<FarmingGround>().sr.color = Color.white;
        }
    }


}
