using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public int power;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        dir = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * 20);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Monster>())
        {
            collision.GetComponent<Monster>().hp -= power;
            collision.GetComponent<Monster>().monsterState = Monster.MonsterState.hit;
            collision.GetComponent<Monster>().hitTimer = 0.2f;
            Destroy(gameObject);
        }
        
    }
}
