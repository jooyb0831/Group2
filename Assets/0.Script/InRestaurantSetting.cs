using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRestaurantSetting : MonoBehaviour
{
    [SerializeField] Transform door;

    [SerializeField] Player p;

    void Start()
    {
        if (SceneChanger.Instance.beforeScreen.Equals("Farm"))
        {
            p.transform.position = door.transform.position;
        }
    }

    void Update()
    {
        
    }
}
