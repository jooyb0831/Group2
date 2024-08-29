using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : Farming
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        data.PlantTitle = "螟熱熱";
        data.SeedTitle = "螟熱熱噢憾";

        data.Harvest_Time = 1440f;
        base.Init();
    }
}
