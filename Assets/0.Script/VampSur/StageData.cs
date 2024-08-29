using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Data/StageData")]
public class StageData : ScriptableObject
{
    [SerializeField] private int stage;
    public int Stage { get { return stage; } }

    [SerializeField] private int monsterNumsMax;
    public int MonsterNumsMax { get { return monsterNumsMax; } }

    [SerializeField] private int[] monsterType;
    public int[] MonsterType { get { return monsterType; } }

    [SerializeField] private float delay;
    public float Delay { get { return delay; } }
}
