using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Transform putPosition;
    //public GameObject item;

    public float Distance = 0.1f;
    private Player p;

    private void Start()
    {
        
    }

    void Update()
    {
        if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                //ItemPutOnTable();
            }
        }
    }

    /*public void ItemPutOnTable()
    {
        item.transform.position = putPosition.position;
        item.GetComponent<Collider2D>().enabled = false;
        // 콜라이더를 비활성화함 => 더 이상 줍지 못하게
    }*/

    public bool LookingAtObject()
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
