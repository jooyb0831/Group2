using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] GameObject timeUI;
    [SerializeField] GameObject hpUI;
    [SerializeField] GameObject spUI;
    [SerializeField] GameObject goldUI;
    [SerializeField] TMP_Text yyTxt;
    [SerializeField] TMP_Text mmTxt;
    [SerializeField] TMP_Text ddTxt;
    [SerializeField] TMP_Text hhTxt;
    [SerializeField] TMP_Text minTxt;
    [SerializeField] TimeSystem ts;
    

    [SerializeField] GameObject notice;

    [SerializeField] Image hpBarImg;
    [SerializeField] Image spBarImg;

    [SerializeField] TMP_Text goldTxt;

    [SerializeField] PlayerData pd;

    [SerializeField] GameObject canvas;
    // Start is called before the first frame update
    

    
    void Start()
    {
        ts = GameManager.Instance.timeSystem;
        pd = GameManager.Instance.pData;
        yyTxt.text = $"{ts.Year}년";
        mmTxt.text = $"{ts.Month:00}월";
        ddTxt.text = $"{ts.Date:00}일";
        minTxt.text = $"{ts.Minute:00}";
        hhTxt.text = $"{ts.Hour:00}";
        goldTxt.text = $"{pd.Gold.ToString("#,##0")}";

        hpBarImg.fillAmount = (float)((float)pd.HP / (float)pd.MAXHP);
        spBarImg.fillAmount = (float)((float)pd.SP / (float)pd.MAXSP);

    }

    // Update is called once per frame
    void Update()
    {
       if(SceneChanger.Instance.screenType.Equals(ScreenType.StagePick) || SceneChanger.Instance.screenType.Equals(ScreenType.VampSur) || SceneChanger.Instance.screenType.Equals(ScreenType.ChangeDate)|| SceneChanger.Instance.screenType.Equals(ScreenType.QuestUI))
       {
            canvas.SetActive(false);
            /*
            timeUI.SetActive(false);
            hpUI.SetActive(false);
            spUI.SetActive(false);
            goldUI.SetActive(false);
            */
       }
       else
       {
            canvas.SetActive(true);
            /*
            timeUI.SetActive(true);
            hpUI.SetActive(true);
            spUI.SetActive(true);
            goldUI.SetActive(true);
            */
        }
    }

    
    public int Year
    {
        set
        {
            yyTxt.text = $"{ts.Year}년";
        }
    }

    public int Month
    {
        set
        {
            mmTxt.text = $"{ts.Month.ToString("00")}월";
        }
    }

    public int Date
    {
        set
        {
            ddTxt.text = $"{ts.Date.ToString("00")}일";
        }
    }

    public int Minute
    {
        set
        {
            minTxt.text = $"{ts.Minute.ToString("00")}";
        }
    }

    public int Hour
    {
        set
        {
            hhTxt.text = $"{ts.Hour.ToString("00")}";
        }
    }

    public int HP
    {
        set
        {
            if(pd == null)
            {
                pd = GameManager.Instance.player.data;
                return;
            }
            hpBarImg.fillAmount = ((float)pd.HP / pd.MAXHP);
        }
    }

    public int SP
    {
        set
        {
            if (pd == null)
            {
                pd = GameManager.Instance.player.data;
                return;
            }
            spBarImg.fillAmount = (float)((float)pd.SP / (float)pd.MAXSP);
        }
    }

    public int Gold
    {
        set
        {
            if(pd == null)
            {
                pd = GameManager.Instance.player.data;
                return;
            }
            goldTxt.text = $"{pd.Gold.ToString("#,###,##0")}";
        }
    }
}
