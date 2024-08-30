using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeDate : MonoBehaviour
{
    [SerializeField] private TMP_Text sleepTxt;
    [SerializeField] private TMP_Text tipsTxt;

    private float timer;
    private string[] sleepStr = { "잠자는중", "잠자는중.", "잠자는중..", "잠자는중..." };
    private string[] tips = 
    { 
        "나무를 벨때마다 스테미나가 소모됩니다", 
        "나무는 하루가 지나면 다시 자라납니다", 
        "인게임에서 10분은 현실에서 5초입니다", 
        "씨앗을 심은 뒤엔 꼭 물을 뿌려주세요", 
        "Shift키를 눌러 달릴 수 있습니다",
        "몬스터는 플레이어 캐릭터가 자동으로 공격합니다",
        "자기전에 작물에게 물을 줬나요?"
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
        Debug.Log("다음날"); //<- 이거 지우고 씬 불러오는 함수 넣기
    }
}
