using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public bool isFilled = false;
    public int indexNum;

    private void Update()
    {
        if(transform.childCount == 1)
        {
            isFilled = true;
        }
        else
        {
            isFilled = false;
        }
    }
}
