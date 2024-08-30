using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeDate : MonoBehaviour
{
    [SerializeField] private TMP_Text sleepTxt;
    [SerializeField] private TMP_Text tipsTxt;

    private float timer;
    private string[] sleepStr = { "���ڴ���", "���ڴ���.", "���ڴ���..", "���ڴ���..." };
    private string[] tips = 
    { 
        "������ �������� ���׹̳��� �Ҹ�˴ϴ�", 
        "������ �Ϸ簡 ������ �ٽ� �ڶ󳳴ϴ�", 
        "�ΰ��ӿ��� 10���� ���ǿ��� 5���Դϴ�", 
        "������ ���� �ڿ� �� ���� �ѷ��ּ���", 
        "ShiftŰ�� ���� �޸� �� �ֽ��ϴ�",
        "���ʹ� �÷��̾� ĳ���Ͱ� �ڵ����� �����մϴ�",
        "�ڱ����� �۹����� ���� �ᳪ��?"
    };
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        tipsTxt.text = $"{tips[Random.Range(0, tips.Length)]}";
        Invoke("NextDay", 5);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        sleepTxt.text = sleepStr[index];
        if (timer >= 0.5f)
        {
            index++;
            if (index >= 4)
            {
                index = 0;
            }
            timer = 0;
        }
    }
    void NextDay()
    {
        Debug.Log("������"); //<- �̰� ����� �� �ҷ����� �Լ� �ֱ�
    }
}
