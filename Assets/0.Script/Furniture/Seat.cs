using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public static Seat Instance { get; private set; }

    public Transform seatPosition;

    public float Distance = 1f;
    public Transform player;

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
        Vector2 dirPlayer = player.position - transform.position;
        dirPlayer.Normalize();

        Ray ray = new Ray(transform.position, dirPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            return hit.transform == player;
        }

        return false;
    }

    private void Interact()
    {
        player.transform.position = seatPosition.position;
    }
}
