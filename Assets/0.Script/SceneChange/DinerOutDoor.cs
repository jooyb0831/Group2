using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinerOutDoor : MonoBehaviour
{
    private Player p;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LookingAtObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneChanger.Instance.GoRestaurant();
            }
        }
    }

    private bool LookingAtObject()
    {
        if(p==null)
        {
            p = GameManager.Instance.player;
        }
        float dist = Vector2.Distance(p.transform.position, transform.position);

        if (dist <= 1 && p.dir.Equals(Direction.Back))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
