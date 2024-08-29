using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class PlayerSprite
{
    public List<Sprite> FrontWalk;
    public List<Sprite> FrontIdle;
    public List<Sprite> FrontWork;
    public List<Sprite> BackWalk;
    public List<Sprite> BackIdle;
    public List<Sprite> BackWork;
    public List<Sprite> SideWalk;
    public List<Sprite> SideIdle;
    public List<Sprite> SideWork;
}

    public enum Direction
    {
        Front,
        Side,
        Back
    }
public class Player : MonoBehaviour
{


    public enum State
    {
        Walk,
        Run,
        Idle,
        Work
    }

    private SpriteAnimation sa;
    public PlayerData data = new PlayerData();
    [SerializeField] PlayerSprite playerSprite;
    [SerializeField] float speed;
    public Direction dir = Direction.Front;
    public State state = State.Idle;
    public bool isWorking = false;
    [SerializeField]bool isMoving = false;

    [SerializeField] Transform objectArea;
    public bool isEquiped = false;

    [SerializeField] private float clampX;
    [SerializeField] private float clampY;
    [SerializeField] private bool clampOnOff;
    void Start()
    {
        DontDestroyOnLoad(this);
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(playerSprite.FrontIdle, 0.2f, true);
        dir = Direction.Front;
        state = State.Idle;
        speed = data.Speed;
        data.MAXHP = 50;
        data.HP =data.MAXHP;
        data.MAXSP = 45;
        data.SP =data.MAXSP;
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log($"HP : {data.HP}");
            Debug.Log($"SP : {data.SP}");
        }
       // Debug.Log($"{state}");
        if (Input.GetKeyDown(KeyCode.E))
        {
            state = State.Work;
            isWorking = true;
            if (dir == Direction.Front)
            {
                sa.SetSprite(playerSprite.FrontWork, 0.1f, false);
            }
            else if (dir == Direction.Side)
            {
                sa.SetSprite(playerSprite.SideWork, 0.1f, false);

            }
            else if (dir == Direction.Back)
            {
                sa.SetSprite(playerSprite.BackWork, 0.1f, false);
            }
            Debug.Log($"{dir}");
        }

        else if(isWorking == false)
        {
            Move();
        }

        //Work();

        //Plant();
    }

    void Move()
    {
        isMoving = true;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            state = State.Run;
            speed = 5f;
        }
        else
        {
            state = State.Walk;
            speed = data.Speed;
        }

        if (clampOnOff)
        {
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
            float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
            float cX = Mathf.Clamp(transform.position.x + x, -clampX, clampX);
            float cY = Mathf.Clamp(transform.position.y + y, -clampY, clampY);
            //transform.Translate(new Vector2(x, y) * Time.deltaTime * speed);
            transform.position = new Vector2(cX, cY);

            SpriteFlip(x, y);
        }
        else
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector3 moveDirection = ((Vector3.right * x) + (Vector3.up * y)).normalized;
            float fixedSpeed = Mathf.Min(((Vector3.right * x) + (Vector3.up * y)).magnitude, 1.0f) * speed;
            transform.Translate(moveDirection * Time.deltaTime * fixedSpeed);

            SpriteFlip(x, y);
        }

    }

    void SpriteFlip(float x, float y)
    {
        if (x!=0)
        {
            if(x>0)
            {
                transform.localScale = new Vector3(5f, 5f, 5f);
            }
            else
            {
                transform.localScale = new Vector3(-5f, 5f, 5f);
            }
            if(state == State.Run)
            {
                sa.SetSprite(playerSprite.SideWalk, 0.1f, true);
            }
            else
            {
                sa.SetSprite(playerSprite.SideWalk, 0.2f, true);
                state = State.Walk;
            }
            dir = Direction.Side;
        }

        else if (y!=0)
        {
            if(y>0)
            {
                if (state == State.Run)
                {
                    sa.SetSprite(playerSprite.BackWalk, 0.1f, true);
                }
                else
                {
                    sa.SetSprite(playerSprite.BackWalk, 0.2f, true);
                    state = State.Walk;
                }
                dir = Direction.Back;
            }
            else if (y<0)
            {
                if (state == State.Run)
                {
                    sa.SetSprite(playerSprite.FrontWalk, 0.1f, true);
                }
                else
                {
                    sa.SetSprite(playerSprite.FrontWalk, 0.2f, true);
                    state = State.Walk;
                }
                dir = Direction.Front;
            }
        }

        else
        {
            if(state == State.Walk || state == State.Run)
            {
                if(dir == Direction.Side)
                {
                    sa.SetSprite(playerSprite.SideIdle, 0.2f, true);
                    
                }
                else if (dir == Direction.Front)
                {
                    sa.SetSprite(playerSprite.FrontIdle, 0.2f, true);
                }
                else if (dir == Direction.Back)
                {
                    sa.SetSprite(playerSprite.BackIdle, 0.2f, true);
                }
                state = State.Idle;
                isMoving = false;
            }
        }

        
    }

    public void Work()
    {
        state = State.Work;
        isWorking = true;
        if (dir == Direction.Front)
        {
            sa.SetSprite(playerSprite.FrontWork, 0.1f, false);
        }
        else if (dir == Direction.Side)
        {
            sa.SetSprite(playerSprite.SideWork, 0.1f, false);

        }
        else if (dir == Direction.Back)
        {
            sa.SetSprite(playerSprite.BackWork, 0.1f, false);
        }
        Debug.Log($"{dir}");
  
    }

    void Plant()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        float dist;

        if(hit.collider == null)
        {
            return;
        }

        if(hit.collider.GetComponent<ActGround>())
        {
            dist = Vector2.Distance(transform.position, hit.collider.transform.position);

            if(dist<2)
            {
                hit.collider.GetComponent<SpriteRenderer>().color = new Color32(145, 145, 145, 255);

                if(Input.GetMouseButtonDown(0) && hit.collider.GetComponent<ActGround>().isPlant == false)
                {
                    if(dir == Direction.Front)
                    {
                        sa.SetSprite(playerSprite.FrontWork, 0.2f,true);
                    }
                    if(dir == Direction.Side)
                    {
                        sa.SetSprite(playerSprite.SideWork, 0.2f, true);
                    }
                    if(dir == Direction.Back)
                    {
                        sa.SetSprite(playerSprite.BackWork, 0.2f, true);
                    }

                    hit.collider.GetComponent<SpriteRenderer>().color = Color.white;
                    //hit.collider.GetComponent<SpriteRenderer>().sprite = hit.collider.GetComponent<ActGround>().plantedTile;
                    hit.collider.GetComponent<ActGround>().isPlant = true;
                }
            }
        }

    }

    [SerializeField] Transform[] quickInvenSlots;
    public bool isToolEquiped = false;
    public string toolName;
    /*
    void ToolCheck()
    {
        quickInvenSlots = QuickInventory.Instance.quickSlots;

        foreach(var item in quickInvenSlots)
        {
            if(item.GetChild(0).GetComponent<Toggle>().isOn)
            {
                if(item.GetChild(0).GetComponent<QuickInvenItem>().data.type.Equals(ItemType. Tool))
                {
                    isToolEquiped = true;
                }

            }
        }
    }
    */
}
