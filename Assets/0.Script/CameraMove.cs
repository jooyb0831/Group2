using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Player p;

    // Update is called once per frame
    void Update()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
            return;
        }

        Vector3 vec = p.transform.position;
        vec.z = -10f;

        transform.position = new Vector3(p.transform.position.x, p.transform.position.y, vec.z);
    }
}
