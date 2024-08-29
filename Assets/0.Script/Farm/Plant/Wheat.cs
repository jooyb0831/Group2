using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : Farming
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        data.PlantTitle = "¹Ð";
        data.SeedTitle = "¹Ð¾¾¾Ñ";
        data.Harvest_Time = 2400f;
        base.Init();
    }

}
