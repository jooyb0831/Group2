using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    [SerializeField] private VSItem item;

    public enum MonsterState
    {
        run,
        att,
        hit,
        dead
    }
    public MonsterState monsterState;
    [SerializeField] private List<Sprite> monsterSprite = new List<Sprite>();
    [SerializeField] private Sprite dead;
    [SerializeField] private Sprite hit;
    public GameObject p;
    private float speed;
    private int power;
    public int hp;
    private float attDelay;
    private float attTime;
    public float hitTimer;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("[Player]");
        monsterState = MonsterState.run;
        hp = monsterData.HP;
        attTime = attDelay;
        speed = monsterData.Speed;
        power = monsterData.Power;
        attDelay = monsterData.AttDelay;
        dead = monsterData.MonsterDeadSprite;
        hit = monsterData.MonsterHitSprite;
        for (int i = 0;i < monsterData.MonsterMoveSprite.Length;i++)
        {
            monsterSprite.Add(monsterData.MonsterMoveSprite[i]);
        }
        gameObject.GetComponent<SpriteAnimation>().SetSprite(monsterSprite, 0.2f, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterState == MonsterState.dead)
        {
            gameObject.GetComponent<SpriteAnimation>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            return;
        }
        attTime += Time.deltaTime;
        //타겟에게로 이동
        float mDis = Vector2.Distance(p.transform.position, transform.position); //플레이어와 몬스터 사이의 거리를 계산후 넣음
        if (mDis > 0.75f)
        {
            Move();
        }
        else
        {
            //monsterState = MonsterState.att;
            if (attTime >= attDelay)
            {
                monsterState = MonsterState.att;
                Attack();
                attTime = 0;
            }
            
        }

        if (hp <= 0)
        {
            Dead();
        }
        if (monsterState == MonsterState.hit)
        {
            gameObject.GetComponent<SpriteAnimation>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = hit;
            hitTimer -= Time.deltaTime;
            if (hitTimer <= 0)
            {
                gameObject.GetComponent<SpriteAnimation>().enabled = true;
                gameObject.GetComponent<SpriteAnimation>().SetSprite(monsterSprite, 0.2f, true);
                monsterState = MonsterState.run;
            }
        }
    }
    void Move()
    {
        if (monsterState != MonsterState.run)
        {
            return;
        }
        //monsterState = MonsterState.run;
        //이동
        Vector2 dis = p.transform.position - transform.position;
        Vector3 dir = dis.normalized * Time.deltaTime * speed; //normalized:방향 감지(1 ~ -1), 바라보기

        //애니메이션방향잡기
        if (dir.normalized.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.normalized.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        transform.Translate(dir);
    }
    void Attack()
    {
        p.GetComponent<Player>().data.HP -= power;
        monsterState = MonsterState.run;
    }
    void Dead()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        monsterState = MonsterState.dead;
        if (Random.Range(1, 101) <= 10)
        {
            VSItem i = Instantiate(item);
            i.transform.position = transform.position;
        }
        VSDefine.killCut++;
        Invoke("RemoveObj", 2);
    }
    void RemoveObj()
    {
        Destroy(gameObject);
    }
}
