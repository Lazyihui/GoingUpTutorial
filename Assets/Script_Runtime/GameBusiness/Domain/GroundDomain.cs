using System;
using UnityEngine;
using DG.Tweening;


public static class GroundDomain
{
    public static GroundEntity Spawn(GameContext ctx, Vector2 pos)
    {
        bool has = ctx.assetsContext.TryGetEntity("Ground_Entity", out GameObject ground);
        if (!has)
        {
            Debug.LogError("Ground_Entity not found");
            return null;
        }
        GameObject go = GameObject.Instantiate(ground);
        GroundEntity groundEntity = go.GetComponent<GroundEntity>();
        groundEntity.Ctor();
        groundEntity.Setpos(pos);
        groundEntity.id = ctx.gameEntity.groundID++;
        ctx.groundRespository.Add(groundEntity);


        return groundEntity;
    }

    public static void Move(GameContext ctx, GroundEntity ground, float dt)
    {
    }

}