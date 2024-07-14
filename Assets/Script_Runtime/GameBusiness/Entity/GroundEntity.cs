using System;
using System.Collections;
using UnityEngine;


public class GroundEntity : MonoBehaviour
{
    public int id;

    public Vector2 step;

    public void Ctor()
    {
        step = new Vector2(1, 0);
    }

    public void Setpos(Vector2 pos)
    {
        transform.position = pos;
    }
}