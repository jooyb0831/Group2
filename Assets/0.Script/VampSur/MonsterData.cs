using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/MonsterData")]
public class MonsterData : ScriptableObject
{
    [SerializeField] private int hp;
    public int HP { get { return hp; } }

    [SerializeField] private Sprite[] monsterMoveSprite;
    public Sprite[] MonsterMoveSprite { get { return monsterMoveSprite; } }

    [SerializeField] private Sprite monsterDeadSprite;
    public Sprite MonsterDeadSprite { get { return monsterDeadSprite; } }

    [SerializeField] private Sprite monsterHitSprite;
    public Sprite MonsterHitSprite { get { return monsterHitSprite; } }

    [SerializeField] private float speed;
    public float Speed { get { return speed; } }

    [SerializeField] private int power;
    public int Power { get { return power; } }

    [SerializeField] private float attDelay;
    public float AttDelay { get { return attDelay; } }
}
