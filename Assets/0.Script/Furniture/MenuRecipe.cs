using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRecipe : MonoBehaviour
{
    public Transform menuPosition;

    public float Distance = 0.1f;
    private Player p;

    void Start()
    {
        if (menuPosition == null)
        {
            menuPosition = GameObject.Find("MenuRecipe").transform;
        }
    }

    void Update()
    {
        if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneChanger.Instance.OpenRecipe();
            }
        }
    }

    private bool LookingAtObject()
    {
        if (p == null)
        {
            p = GameManager.Instance.player;
        }
        float dist = Vector2.Distance(p.transform.position, transform.position);

        if (dist <= 1)
        {
            return true;
        }
        else
        {
            return false;
        }

        /*Vector2 dirToPlayer = player.position - transform.position;
        dirToPlayer.Normalize();

        Ray ray = new Ray(transform.position, dirToPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            return hit.transform == player;
        }

        return false;*/
    }
}
