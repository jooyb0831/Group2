using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSManager : MonoBehaviour
{
    [SerializeField] private Player p;
    [SerializeField] private DeadPlayer dp;
    [SerializeField] private MonsterSpon ms;

    private bool dpBool;
    // Start is called before the first frame update
    void Start()
    {
        dpBool = false;
        VSDefine.killCut = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (p.data.HP <= 0 && !dpBool)
        {
            DeadPlayer d = Instantiate(dp);
            d.transform.position = new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z);
            p.gameObject.SetActive(false);
            dpBool = true;
            VSDefine.gameState = VSDefine.GameState.end;
        }

        if (VSDefine.killCut >= ms.monsterNumsMax)
        {
            VSDefine.gameState = VSDefine.GameState.end;
        }


        if (VSDefine.speedTimer > 0)
        {
            VSDefine.speedTimer -= Time.deltaTime;
            p.data.Speed = 5;
        }
        else if (VSDefine.speedTimer <= 0)
        {
            p.data.Speed = 3;
        }
    }
}
