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
    private Player p;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GoFarm()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
        }
        StartCoroutine("FadeScreen");
        SceneManager.LoadScene("Farm");
        p.transform.position = new Vector2(6.48f, 1.2f);
        //p.transform.position = beforePos;
        if (SceneManager.GetActiveScene().name == "GameUI")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        }
        //SceneManager.LoadScene("GameUI", LoadSceneMode.Additive); //°ÔÀÓ¾À¿¡ UI¸¦ ¾ñ´Â´Ù °°Àº ´À³¦
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoHome()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
        }
        StartCoroutine("FadeScreen");
        SceneManager.LoadScene("InHouse");
        p.transform.position = new Vector2(0, -3.3f);
        //p.transform.position = afterPos;
        SceneManager.LoadScene("InHouse");

        if(SceneManager.GetActiveScene().name == "GameUI")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        }
    }

    public void GoRestaurant()
    {
        SceneManager.LoadScene("InRestaurant");
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
        SceneManager.LoadScene("Logging");
        if (SceneManager.GetActiveScene().name == "GameUI")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene("GameUI", LoadSceneMode.Additive);
        }
    }
    IEnumerator FadeScreen()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        GameObject obj = Instantiate(blackScreen, transform.GetChild(0));
        obj.GetComponent<Image>().DOFade(0, 2f);
        yield return new WaitForSeconds(2f);
        transform.GetChild(0).gameObject.SetActive(false);
        Destroy(obj);
    }
}
