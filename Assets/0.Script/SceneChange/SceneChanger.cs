using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : Singleton<SceneChanger>
{
    public Vector2 beforePos;
    public Vector2 afterPos;
    [SerializeField] GameObject blackScreen;
    [SerializeField] GameObject ground;
    [SerializeField] Player p;
    public ScreenType screenType = ScreenType.Farm;

    public ScreenType beforeScreen;
    public bool isFarm = true;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
            return;
        }
    }

    public void GoGame()
    {
        StartCoroutine("FadeScreen");
        SceneManager.LoadScene("Farm");
        p = GameManager.Instance.player;
        screenType = ScreenType.Farm;
        ground.transform.position = Vector3.zero;
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("Continuous", LoadSceneMode.Additive);
        SceneManager.LoadScene("NPC", LoadSceneMode.Additive);
    }

    public void GoFarm()
    {
        SceneManager.LoadScene("Farm");
        StartCoroutine("FadeScreen");

        p = GameManager.Instance.player;
        screenType = ScreenType.Farm;
        //isFarm = true;
        ground.transform.position = Vector3.zero;
        //p.transform.position = new Vector2(6.48f, 1.2f);
        //p.transform.position = beforePos;\

        /*
        if (SceneManager.GetActiveScene().name == "GameUI")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        }
        */
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive); //°ÔÀÓ¾À¿¡ UI¸¦ ¾ñ´Â´Ù °°Àº ´À³¦
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoHome()
    {
        screenType = ScreenType.House;
        SceneManager.LoadScene("InHouse");
        StartCoroutine("FadeScreen");
        PlayerPosition.Instance.p = GameManager.Instance.player;
        PlayerPosition.Instance.Check();
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        ground.transform.position = new Vector2(100, 100);
        
        /*
        if (SceneManager.GetActiveScene().name == "GameUI")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        }
        */
    }

    public void GoRestaurant()
    {
        StartCoroutine("FadeScreen");
        SceneManager.LoadScene("InRestaurant");

        if (p == null)
        {
            p = GameManager.Instance.player;
        }
        p.transform.position = new Vector2(0, -3.3f);
        screenType = ScreenType.Diner;
        ground.transform.position = new Vector2(100, 100);
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
    }

    public void OnDialogue()
    {
        SceneManager.LoadScene("NPC_ChatUI", LoadSceneMode.Additive);
    }

    public void ToSleep()
    {
        SceneManager.LoadScene("Notice", LoadSceneMode.Additive);
    }

    public void WatchTV()
    {
        SceneManager.LoadScene("Notice", LoadSceneMode.Additive);
    }

    public void OpenDrawer()
    {
        SceneManager.LoadScene("Drawer", LoadSceneMode.Additive);
    }

    public void OpenRefri()
    {
        SceneManager.LoadScene("Refrigerator", LoadSceneMode.Additive);
    }

    public void OpenOven()
    {
        SceneManager.LoadScene("Oven", LoadSceneMode.Additive);

    }
    public void OpenRecipe()
    {
        SceneManager.LoadScene("MenuListUI", LoadSceneMode.Additive);
    }

    public void GoForest()
    {
        if (p == null)
        {
            p = GameManager.Instance.player;
        }
        StartCoroutine("FadeScreen");
        ground.transform.position = new Vector2(100, 100);
        SceneManager.LoadScene("Logging");
        screenType = ScreenType.Forest;
        //ground.SetActive(false);
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
    }

    public void GoVampSur()
    {
        SceneManager.LoadScene("VampSur");
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("VampSurUI", LoadSceneMode.Additive);
        screenType = ScreenType.VampSur;
    }

    public void GoDunGeonSelect()
    {
        StartCoroutine("FadeScreen");
        ground.transform.position = new Vector2(100, 100);
        SceneManager.LoadScene("StagePick");
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        screenType = ScreenType.StagePick;
    }

     public void GoQuest()
    {
        SceneManager.LoadScene("QuestUI");
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        screenType = ScreenType.QuestUI;
    }

    public void Sleep()
    {
        StartCoroutine("FadeScreen");
        SceneManager.LoadScene("ChangeDate");
        SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        screenType = ScreenType.ChangeDate;
    }


    IEnumerator FadeScreen()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        //PlayerPosition.Instance.Check();
        GameObject obj = Instantiate(blackScreen, transform.GetChild(0));
        obj.GetComponent<Image>().DOFade(0, 2f);
        yield return new WaitForSeconds(2f);
        transform.GetChild(0).gameObject.SetActive(false);
        Destroy(obj);
    }

}
