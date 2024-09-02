using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoor : MonoBehaviour
{
    public CanvasGroup screenFader;

    public float Distance = 1f;
    private Player p;

    private bool isArea = false;

    void Start()
    {
       

        /*
        if (screenFader == null)
        {
            //screenFader = GameObject.Find("Fade").GetComponent<CanvasGroup>();
        }
        */
    }

    void Update()
    {
        if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneChanger.Instance.beforeScreen = ScreenType.Farm;
                SceneChanger.Instance.GoHome();
                //StartCoroutine(FadeScreen());
            }
        }
    }

    private bool LookingAtObject()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
        }
        float dist = Vector2.Distance(p.transform.position, transform.position);

        if(dist<=1 && p.dir.Equals(Direction. Back))
        {
            return true;
        }
        else
        {
            return false;
        }

        /*
        Vector2 dirToPlayer = player.position - transform.position;
        dirToPlayer.Normalize();

        Ray ray = new Ray(transform.position, dirToPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            return hit.transform == player;
        }

        return false;
        */
    }

    private IEnumerator FadeScreen()
    {
        float duration = 2f;
        float currentime = 0f;

        while (currentime < duration)
        {
            currentime += Time.deltaTime;
            screenFader.alpha = Mathf.Lerp(0, 1, currentime / duration);
            yield return null;
        }
    }
}
