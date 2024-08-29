using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRecipe : MonoBehaviour
{
    public Transform menuPosition;

    public float Distance = 1f;
    //public Transform player;

    void Start()
    {
        if (menuPosition == null)
        {
            menuPosition = GameObject.Find("MenuRecipe").transform;
        }
    }

    void Update()
    {
        //if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneChanger.Instance.OpenRecipe();
            }
        }
    }

    /*private bool LookingAtObject()
    {
        Vector2 dirToPlayer = player.position - transform.position;
        dirToPlayer.Normalize();

        Ray ray = new Ray(transform.position, dirToPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            return hit.transform == player;
        }

        return false;
    }*/
}
