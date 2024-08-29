using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    SpriteRenderer sr;

    public List<Sprite> frontWalk;
    public List<Sprite> frontIdle;
    public List<Sprite> frontWork;

    public List<Sprite> siedWalk;
    public List<Sprite> sideIdle;
    public List<Sprite> sideWork;

    public List<Sprite> backWalk;
    public List<Sprite> backIdle;
    public List<Sprite> backWork;

    public List<Sprite> sprites;
    private float delay;

    private int index = 0;
    private bool loop = true;
    private bool isReset = false;
    private float timer;
    private Player p;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteAct();
    }

    void SpritePlay()
    {
        if(sprites.Count == 0)
        {
            return;
        }

        timer += Time.deltaTime;
        if(timer>=delay)
        {
            timer = 0f;
            index++;

            if(index>=sprites.Count)
            {
                index = 0;
            }
            sr.sprite = sprites[index];
        }
    }

    void SpriteAct()
    {
        if (sprites.Count == 0)
        {
            return;
        }
        timer += Time.deltaTime;

        if(timer>=delay)
        {
            sr.sprite = sprites[index];
            index++;
            timer = 0;
        }

        if (index > sprites.Count-1)
        {
            index = 0;
            if (loop == false)
            {
                if(transform.GetComponent<Player>())
                {
                    if (p == null)
                    {
                        p = GameManager.Instance.player;
                    }
                    p.isWorking = false;
                }


            }
            
        }
    }

    public void SetSprite(List<Sprite> sprites, float delay, bool loop)
    {
        if(sr == null)
        {
            sr.GetComponent<SpriteRenderer>();
        }
        this.sprites = sprites;
        this.delay = delay;
        this.loop = loop;
    }

    public void ReSprite()
    {
        isReset = true;
        sprites = null;
    }


}
