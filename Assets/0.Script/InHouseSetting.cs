using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHouseSetting : MonoBehaviour
{
    [SerializeField] Transform door;
    [SerializeField] Transform bed;

    [SerializeField]  Player p;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if (SceneChanger.Instance.beforeScreen.Equals("Farm"))
        {
            p.transform.position = door.transform.position;
        }

        if (SceneChanger.Instance.beforeScreen.Equals("ChangeDate"))
        {
            p.transform.position = bed.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
