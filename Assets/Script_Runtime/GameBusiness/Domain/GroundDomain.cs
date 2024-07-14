using System;
using UnityEngine;
using DG.Tweening;


public static class GroundDomain
{
    public static GroundEntity Spawn(GameContext ctx, Vector2 pos, int typeID)
    {
        if (typeID == 0)
        {

            bool has = ctx.assetsContext.TryGetEntity("Ground_Entity", out GameObject ground);

            GameObject go = GameObject.Instantiate(ground);
            GroundEntity groundEntity = go.GetComponent<GroundEntity>();
            groundEntity.Ctor();
            groundEntity.Setpos(pos);
            groundEntity.id = ctx.gameEntity.groundID++;
            ctx.groundRespository.Add(groundEntity);


            return groundEntity;
        }
        else
        {
            bool has = ctx.assetsContext.TryGetEntity("Goal_Entity", out GameObject goal);

            GameObject go = GameObject.Instantiate(goal);
            GroundEntity goalEntity = go.GetComponent<GroundEntity>();
            goalEntity.Ctor();
            goalEntity.Setpos(pos);
            goalEntity.id = ctx.gameEntity.groundID++;
            ctx.groundRespository.Add(goalEntity);

            return goalEntity;
        }
    }

    public static void Move(GameContext ctx, GroundEntity ground, float dt)
    {
        ground.transform.DOMove(ground.transform.position + Vector3.up * 2f, 0.5f);
    }

}