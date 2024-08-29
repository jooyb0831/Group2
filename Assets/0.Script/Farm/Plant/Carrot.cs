using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Farming
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        data.PlantTitle = "´ç±Ù";
        data.SeedTitle = "´ç±Ù¾¾¾Ñ";

        data.Harvest_Time = 720f;
        base.Init();
    }
}
