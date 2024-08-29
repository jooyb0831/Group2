using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Transform putPosition;
    public GameObject item;

    public float Distance = 1f;
    public Transform player;

    private void Start()
    {
        
    }

    void Update()
    {
        if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                ItemPutOnTable();
            }
        }
    }

    public void ItemPutOnTable()
    {
        item.transform.position = putPosition.position;
        item.GetComponent<Collider2D>().enabled = false;
        // 콜라이더를 비활성화함 => 더 이상 줍지 못하게
    }

    public bool LookingAtObject()
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
}
