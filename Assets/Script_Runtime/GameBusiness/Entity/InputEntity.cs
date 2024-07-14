using System;
using System.Collections;
using UnityEngine;

public class InputEntity
{
    public Vector2 step;

    public float inputKeyIndex;


    public void Process()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputKeyIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputKeyIndex = -1;
        }
    }
}