using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public static Seat Instance { get; private set; }

    public Transform seatPosition;

    public float Distance = 0.1f;
    private Player p;

    void Start()
    {
        if (seatPosition == null)
        {
            seatPosition = GameObject.Find("Chair").transform;
        }
    }

    void Update()
    {
        if (LookigAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }
    }

    private bool LookigAtObject()
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

        /*Vector2 dirPlayer = player.position - transform.position;
        dirPlayer.Normalize();

        Ray ray = new Ray(transform.position, dirPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            return hit.transform == player;
        }

        return false;*/
    }

    private void Interact()
    {
        p.transform.position = seatPosition.position;
    }
}
