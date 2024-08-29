using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamClamp : MonoBehaviour
{
    [SerializeField] private Player p;

    [SerializeField] private float clampX;
    [SerializeField] private float clampY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(p.transform.position.x, -clampX, clampX);
        float y = Mathf.Clamp(p.transform.position.y, -clampY, clampY);
        transform.position = new Vector3(x, y, -10);
    }
}
