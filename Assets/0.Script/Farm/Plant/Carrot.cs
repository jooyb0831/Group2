using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Farming
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
        Init();
    }

    public override void Init()
    {
        data.PlantTitle = "���";
        data.SeedTitle = "��پ���";
        data.Harvest_Time = 720f;
        base.Init();
    }
}
