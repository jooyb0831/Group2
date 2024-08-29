using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [HideInInspector] public float time_s;
    [HideInInspector] public int time_m;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VSDefine.gameState == VSDefine.GameState.play)
        {
            time_s += Time.deltaTime;
        }
        if (time_s >= 60)
        {
            time_m++;
            time_s = 0;
        }
    }
}
