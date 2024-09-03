using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmScene : Singleton<FarmScene>
{
    public Transform centerPos;
    public Transform houseDoorPos;
    public Transform forestPos;
    public Transform questPos;
    [SerializeField] GameObject p;
    public bool isLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Check()
    {
        if (SceneChanger.Instance.beforePos.Equals(ScreenType.House))
        {
            GameObject player = Instantiate(p, houseDoorPos);
            player.transform.SetParent(null);
        }

        if(SceneChanger.Instance.beforePos.Equals(ScreenType.Forest))
        {
            GameObject player = Instantiate(p, forestPos);
            player.transform.SetParent(null);
        }
        isLoaded = true;
    }
}
