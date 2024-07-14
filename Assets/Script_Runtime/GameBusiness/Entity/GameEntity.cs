using System;
using UnityEngine;

public class gameEntity
{
    public float restFixTime;

    public int groundCount;

    public int playerID;
    public int groundID;
    public Vector2 step;

    public gameEntity()
    {
        restFixTime = 0;
        groundCount = 10;
        step = new Vector2(4.25f, 7.5f);
    }
}