using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Data/PlantData")]
public class Plant : ScriptableObject
{
    [SerializeField] private int index;
    public int Index { get { return index; } }

    [SerializeField] private Sprite icon;
    public Sprite Icon { get { return icon; } }

    [SerializeField] private string plant_name;
    public string Name { get { return plant_name; } }

    [SerializeField] private string description;
    public string Description { get { return description; } }
}
