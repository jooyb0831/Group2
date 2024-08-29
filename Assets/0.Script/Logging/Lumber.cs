using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumber : MonoBehaviour
{
    public GameObject p;

    public int maxBounce;	// �ñ�� Ƚ��

    public float xForce;	// x�� �� (�� �ָ�)
    public float yForce;	// Y�� �� (�� ����)
    public float gravity;	// �߷� (�������� �ӵ� ����)

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
        //�ִϸ��̼�
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
        //�ִϸ��̼�
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
        //�÷��̾� ����
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
            //������ ȹ��
            Destroy(gameObject);
        }
    }
    void OnGoInven()
    {
        goInven = true;
    }
    
    //�ִϸ��̼�
    void Initialize(Vector2 _direction)
    {
        isGrounded = false;
        maxHeight /= 1.5f;
        direction = _direction;
        currentheight = maxHeight;
        currentBounce++;
    }

    //�ִϸ��̼�
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
