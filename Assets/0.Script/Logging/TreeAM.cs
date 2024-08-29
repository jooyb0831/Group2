using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAM : MonoBehaviour
{
    [SerializeField] private Tree t;

    private bool rl;
    private float posX;
    // Start is called before the first frame update
    void Start()
    {
        rl = true;
        posX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < posX)
        {
            rl = true;
        }
        else if (transform.position.x > posX)
        {
            rl = false;
        }

        if (!t.logging)
        {
            if (rl)
            {
                transform.Translate(Vector2.right * Time.deltaTime * 50);
            }
            else
            {
                transform.Translate(Vector2.left * Time.deltaTime * 50);
            }
        }
        
    }
}
