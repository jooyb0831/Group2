using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string itemTitle;
    public Sprite fieldIcon;
    public ItemType itemType; 
    public Sprite invenIcon;
    public Sprite invenBGSprite;
    public int plusEnergy;
    public int price;
    public int count;
}
public class FieldItem : MonoBehaviour
{
    [SerializeField] public ItemData itemData;
    private Player p;
    private PlantData plantData;
    public bool isFind = false;

    //복사한거
    //public GameObject p;

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
    // Start is called before the first frame update
    void Start()
    {
        //애니메이션
        currentheight = Random.Range(yForce - 1, yForce);
        maxHeight = currentheight;
        Initialize(new Vector2(Random.Range(-xForce, xForce), Random.Range(-xForce, xForce)));

        //p = GameObject.Find("[Player]");
        goInven = false;
        Invoke("OnGoInven", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
            return;
        }

        if(isFind == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, p.transform.position, Time.deltaTime * 5f);
            float distance = Vector3.Distance(transform.position, p.transform.position);

            if(distance<0.2f)
            {
                Destroy(gameObject);
                Inventory.Instance.GetItem(itemData);
            }
        }

        else
        {
            float distance = Vector3.Distance(transform.position, p.transform.position);

            if (distance <= 3f)
            {
                isFind = true;
            }
        }

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
