using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumber : MonoBehaviour
{
    public GameObject p;

    public int maxBounce;	// 팅기는 횟수

    public float xForce;	// x축 힘 (더 멀리)
    public float yForce;	// Y축 힘 (더 높이)
    public float gravity;	// 중력 (떨어지는 속도 제어)

    private Vector2 direction;
    private int currentBounce = 0;
    private bool isGrounded = true;

    private float maxHeight;
    private float currentheight;

    public Transform sprite;
    public Transform shadow;

    private bool goInven;
    void Start()
    {
        //애니메이션
        currentheight = Random.Range(yForce - 1, yForce);
        maxHeight = currentheight;
        Initialize(new Vector2(Random.Range(-xForce, xForce), Random.Range(-xForce, xForce)));

        p = GameObject.Find("[Player]");
        goInven = false;
        Invoke("OnGoInven", 2);
    }

    void Update()
    {
        if (sprite == null)
        {
            Destroy(gameObject);
        }
        //애니메이션
        if (!isGrounded && sprite != null)
        {

            currentheight += -gravity * Time.deltaTime;
            sprite.position += new Vector3(0, currentheight, 0) * Time.deltaTime;
            transform.position += (Vector3)direction * Time.deltaTime;

            float totalVelocity = Mathf.Abs(currentheight) + Mathf.Abs(maxHeight);
            float scaleXY = Mathf.Abs(currentheight) / totalVelocity;
            shadow.localScale = Vector2.one * Mathf.Clamp(scaleXY, 0.5f, 1.0f);

            CheckGroundHit();
        }
        //플레이어 따라감
        if (goInven)
        {
            float mDis = Vector2.Distance(p.transform.position, transform.position);
            Vector2 dis = p.transform.position - transform.position;
            Vector3 dir = dis.normalized * Time.deltaTime * 20;
            transform.Translate(dir);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            //아이템 획득
            Destroy(gameObject);
        }
    }
    void OnGoInven()
    {
        goInven = true;
    }
    
    //애니메이션
    void Initialize(Vector2 _direction)
    {
        isGrounded = false;
        maxHeight /= 1.5f;
        direction = _direction;
        currentheight = maxHeight;
        currentBounce++;
    }

    //애니메이션
    void CheckGroundHit()
    {
        if (sprite.position.y < shadow.position.y)
        {
            sprite.position = shadow.position;
            shadow.localScale = Vector2.one;

            if (currentBounce < maxBounce)
            {
                Initialize(direction / 1.5f);
            }
            else
            {
                isGrounded = true;
            }
        }
    }
}
