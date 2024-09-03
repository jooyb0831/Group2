using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScreenType
{
    Farm,
    House,
    Diner,
    Forest,
    StagePick,
    VampSur,
    ChangeDate,
    QuestUI
}

public class ScreenController : MonoBehaviour
{
    [SerializeField] Player p;
    [SerializeField] Transform pos;
    private void Awake()
    {
        var obj = FindObjectsOfType<ScreenController>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Check()
    {
        if(SceneChanger.Instance.screenType.Equals(ScreenType.Farm))
        {
            GameObject pl = Instantiate(p.gameObject, pos);
        }
    }

}
