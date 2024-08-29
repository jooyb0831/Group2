using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    //public Vector3 dir;
    public bool comeBack;
    public GameObject p;
    public GameObject target;
    public int power;
    private void Awake()
    {
        comeBack = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("[Player]");
        //comeBack = false;
        //FindMonster();
        power = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!comeBack)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10);
            //float mDis = Vector2.Distance(target.transform.position, transform.position);
            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 20f);
        }
        else
        {
            float mDis = Vector2.Distance(p.transform.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, p.transform.position, Time.deltaTime * 10f);
            //float distance = Vector3.Distance(transform.position, p.transform.position);
            if (mDis < 0.75f)
            {
                Destroy(gameObject);
            }
            //Vector2 dis = p.transform.position - transform.position;
            //Vector3 dir = dis.normalized * Time.deltaTime * 20; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Monster>())
        {
            collision.GetComponent<Monster>().hp -= power;
            collision.GetComponent<Monster>().monsterState = Monster.MonsterState.hit;
            collision.GetComponent<Monster>().hitTimer = 0.2f;
        }
    }
}
