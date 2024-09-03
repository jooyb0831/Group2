using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : Singleton<PlayerPosition>
{
    public Player p;
    public bool isSet = false;
    [SerializeField] Transform[] playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(p == null)
        {
            p = GameManager.Instance.player;
            return;
        }

    }

    public void Check()
    {
        if (SceneChanger.Instance.screenType.Equals(ScreenType. House))
        {
            if(SceneChanger.Instance.beforeScreen.Equals(ScreenType.Farm))
            {
                p.dir = Direction.Back;
                p.transform.position = new Vector2(0, -3.3f);
                isSet = true;
            }
        }
    }
}
