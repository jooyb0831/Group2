using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : Farming
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        Init();
    }

    public override void Init()
    {
        data.PlantTitle = "������";
        data.SeedTitle = "����������";

        data.Harvest_Time = 1440f;
        base.Init();
    }
}
