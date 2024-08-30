using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerData : MonoBehaviour
{
    public string playerName { get; set; }

    private int hp=50;
    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            if (SceneManager.GetActiveScene().name == "VampSur")
            {
                VSUI.Instance.hp = hp;
            }
            else
            {
                GameUI.Instance.HP = hp;
            }
        }
    }

    private int sp = 45;
    public int SP
    {
        get { return sp; }
        set
        {
            sp = value;
            if (SceneManager.GetActiveScene().name != "VampSurUI")
            {
                GameUI.Instance.SP = sp;
            }
        }
    }
    public int MAXSP { get; set; } = 45;

    public int MAXHP { get; set; } = 50;

    private int exp;
    public int EXP
    {
        get { return exp; }
        set
        {
            exp = value;
        }
    }

    public int MAXEXP { get; set; }

    private int gold=0;
    public int Gold 
    { 
        get { return gold; }
        set
        {
            gold = value;
            GameUI.Instance.Gold = gold;
        } 
    }


    public float Speed { get; set; } = 3f;

    private void Start()
    {
        DontDestroyOnLoad(this);
        MAXHP = 50;
        HP = MAXHP;
        MAXSP = 45;
        SP = MAXSP;
    }
}
