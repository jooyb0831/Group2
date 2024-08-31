using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFarm : MonoBehaviour
{
    private Player p;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (p == null)
        {
            p = GameManager.Instance.player;
            return;
        }
        float dist = Vector2.Distance(p.transform.position, transform.position);

        if (dist < 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneChanger.Instance.beforePos = transform.position;
                SceneChanger.Instance.GoFarm();
            }

        }
    }

    public void OnBackBtn()
    {
        SceneChanger.Instance.GoFarm();
    }
}
