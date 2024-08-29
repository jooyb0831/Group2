using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject hoe;
    [SerializeField] private Transform bs;

    private float timer1;
    private float timer2;
    private float fireDelay;
    private float hoeDelay;
    public int power;
    // Start is called before the first frame update
    void Start()
    {
        fireDelay = 0.2f;
        hoeDelay = 5;
        timer1 = fireDelay;
        timer2 = hoeDelay;
        power = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        Fire();
        Hoe();
    }
    private void Fire()
    {
        if (timer1 >= fireDelay)
        {
            GameObject[] monsObjs = GameObject.FindGameObjectsWithTag("Monster");
            float targetDis = 999;
            int index = -1;
            for (int i = 0; i < monsObjs.Length; i++)
            {
                float dis = Vector2.Distance(transform.position, monsObjs[i].transform.position);
                if (dis <= 6)
                {
                    if (targetDis >= dis)
                    {
                        targetDis = dis;
                        index = i;
                    }
                }
            }
            if (index == -1 || monsObjs[index].GetComponent<Monster>().monsterState == Monster.MonsterState.dead)
            {
                return;
            }
            FirePosRotation(monsObjs[index]);
            GameObject b = Instantiate(bullet, transform.parent);
            b.transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
            //b.GetComponent<Bullet>().target = monsObjs[index];
            b.GetComponent<Bullet>().power = power;
            b.transform.parent = bs.parent;

            timer1 = 0;
        }
    }
    private void FirePosRotation(GameObject m)
    {
        Vector2 vec = transform.position - m.transform.position;
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
    void Hoe()
    {
        if (timer2 >= hoeDelay)
        {
            GameObject[] monsObjs = GameObject.FindGameObjectsWithTag("Monster");
            float targetDis = 999;
            int index = -1;
            for (int i = 0; i < monsObjs.Length; i++)
            {
                float dis = Vector2.Distance(transform.position, monsObjs[i].transform.position);
                if (dis <= 6)
                {
                    if (targetDis >= dis)
                    {
                        targetDis = dis;
                        index = i;
                    }
                }
            }
            if (index == -1 || monsObjs[index].GetComponent<Monster>().monsterState == Monster.MonsterState.dead)
            {
                return;
            }
            FirePosRotation(monsObjs[index]);
            GameObject h = Instantiate(hoe, transform.parent);
            h.transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
            h.transform.parent = bs.parent;

            timer2 = 0;
        } 
    }
}
