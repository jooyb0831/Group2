using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drawer : MonoBehaviour
{
    public Transform drawerPosition;

    public float Distance = 1f;
    public Transform player;

    void Start()
    {
        if (drawerPosition == null)
        {
            drawerPosition = GameObject.Find("Drawer").transform;
        }
    }

    void Update()
    {
        if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }
    }

    private bool LookingAtObject()
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
    }

    private void Interact()
    {
        SceneChanger.Instance.OpenDrawer();
    }
}
