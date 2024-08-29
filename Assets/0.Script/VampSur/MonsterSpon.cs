using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpon : MonoBehaviour
{
    [SerializeField] private Monster monster;
    [SerializeField] private MonsterData[] md;
    [SerializeField] private StageData[] sds;

    private StageData data;
    private float timer;
    private float delay;
    private int monsterNums;
    [HideInInspector] public int monsterNumsMax;
    private int[] monsterType;
    // Start is called before the first frame update
    void Start()
    {
        data = sds[VSDefine.presentStage - 1];
        timer = 0;
        delay = data.Delay;
        monsterNums = 0;
        monsterNumsMax = data.MonsterNumsMax;
        monsterType = data.MonsterType;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay && monsterNums < monsterNumsMax)
        {
            int sponerDir = Random.Range(1, 5);
            switch (sponerDir)
            {
                case 1:
                    {
                        float x = Random.Range(-14.5f, 14.5f);
                        transform.position = new Vector3(x, 12f, 0);
                        break;
                    }
                case 2:
                    {
                        float x = Random.Range(-14.5f, 14.5f);
                        transform.position = new Vector3(x, -12f, 0);
                        break;
                    }
                case 3:
                    {
                        float y = Random.Range(-12f, 12f);
                        transform.position = new Vector3(14.5f, y, 0);
                        break;
                    }
                case 4:
                    {
                        float y = Random.Range(-12f, 12f);
                        transform.position = new Vector3(-14.5f, y, 0);
                        break;
                    }
                default:
                    {
                        Debug.Log("오류 발생");
                        break;
                    }
            }
            Monster m = Instantiate(monster);
            m.monsterData = md[monsterType[Random.Range(0, monsterType.Length)]];
            m.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            timer = 0;
            monsterNums++;
        }
    }
}
