using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClamp : MonoBehaviour
{
    [SerializeField] private float clampX;
    [SerializeField] private float clampY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(transform.position.x, -clampX, clampX);
        float y = Mathf.Clamp(transform.position.y, -clampY, clampY);
    }
}
