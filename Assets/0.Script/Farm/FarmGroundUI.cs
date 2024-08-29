using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmGroundUI : Singleton<FarmGroundUI>
{
    [SerializeField] TMP_Text plantNameTxt;
    [SerializeField] TMP_Text durationTxt;
    [SerializeField] Image growBar;
    private Farming farming;
    private float timer;
    private float fullTime;
    // Start is called before the first frame update
    void Start()
    {

        plantNameTxt.text = transform.parent.GetComponent<Farming>().data.PlantTitle;
        fullTime = transform.parent.GetComponent<Farming>().data.Harvest_Time;
        int date = (int)((fullTime - transform.parent.GetComponent<Farming>().Timer) / 720);
        int hour = (int)(((fullTime - transform.parent.GetComponent<Farming>().Timer) % 720) / 30);
        int minute = (int)((((((fullTime - transform.parent.GetComponent<Farming>().Timer) % 720) % 30)) / 5) * 10);
        durationTxt.text = $"{date}일 {hour}시간 {minute.ToString("#0")}분";
        growBar.fillAmount = (transform.parent.GetComponent<Farming>().Timer / fullTime);

    }


    
    private float durationTime;
    public float DurationTime
    {
        get { return transform.parent.GetComponent<Farming>().Timer; }
        set
        {
            if(transform.parent.GetComponent<Farming>().isGrown == true)
            {
                growBar.fillAmount = 1f;
                durationTxt.text = $"수확가능!";
            }
            else
            {
                int date = (int)((fullTime - transform.parent.GetComponent<Farming>().Timer) / 720);
                int hour = (int)(((fullTime - transform.parent.GetComponent<Farming>().Timer) % 720) / 30);
                int minute = (int)((((((fullTime - transform.parent.GetComponent<Farming>().Timer) % 720) % 30)) / 5) * 10);
                durationTxt.text = $"{date}일 {hour}시간 {minute.ToString("#0")}분";
                growBar.fillAmount = (transform.parent.GetComponent<Farming>().Timer / fullTime);
            }

        }
    }
    
    
}
