using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSItem : MonoBehaviour
{
    [SerializeField] private Sprite[] itemSprite;

    private enum ItemKind
    {
        recovery,
        speed
    }
    private ItemKind itemKind;
    // Start is called before the first frame update
    void Start()
    {
        itemKind = (ItemKind)Random.Range(0, 2);
        gameObject.GetComponent<SpriteRenderer>().sprite = itemSprite[(int)itemKind];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            switch (itemKind)
            {
                case ItemKind.recovery:
                {
                    collision.GetComponent<Player>().data.HP += 10;
                    if (collision.GetComponent<Player>().data.HP > 50)
                    {
                        collision.GetComponent<Player>().data.HP = 50;
                    }
                    break;
                }
                case ItemKind.speed:
                {
                    VSDefine.speedTimer = VSDefine.speedDelay;
                    break;
                }
            }
            Destroy(gameObject);
        }
    }
}
