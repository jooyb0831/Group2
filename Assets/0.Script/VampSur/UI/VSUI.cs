using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class VSUI : Singleton<VSUI>
{
    [SerializeField] private Timer gm;
    [SerializeField] private TMP_Text clearTimeTxt;
    [SerializeField] private Image ending;
    [SerializeField] private Image hpBar;
    [SerializeField] private TMP_Text killCut;
    [SerializeField] private TMP_Text inGameKillCut;

    public int hp;
    private int maxHp;

    private Player p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameManager.Instance.player;
        maxHp = p.data.MAXHP;
        hp = p.data.HP;
        hpBar.fillAmount = (float)hp / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (p == null)
        {
            p = GameManager.Instance.player;
        }

        if ((int)gm.time_s <= 9)
        {
            clearTimeTxt.text = $"{gm.time_m} : 0{(int)gm.time_s}";
        }
        else
        {
            clearTimeTxt.text = $"{gm.time_m} : {(int)gm.time_s}";
        }

        hpBar.fillAmount = (float)hp / (float)maxHp;

        inGameKillCut.text = $"{VSDefine.killCut}";

        if (VSDefine.gameState == VSDefine.GameState.end)
        {
            Invoke("EndingWid", 1);
        }
    }
    void EndingWid()
    {
        ending.gameObject.SetActive(true);
        killCut.text = $"처치한 적 : {VSDefine.killCut}";
    }
    public void GoPick()
    {
        SceneManager.LoadScene("StagePick");
    }
}
