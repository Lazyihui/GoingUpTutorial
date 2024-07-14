using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public static class PlayerDomain
{
    public static PlayerEntity Spawn(GameContext ctx)
    {
        Debug.Assert(ctx != null);
        Debug.Assert(ctx.assetsContext != null);
        Debug.Assert(ctx.playerRespository != null);
        
        bool has = ctx.assetsContext.TryGetEntity("Player_Entity", out GameObject player);
        if(!has)
        {
            Debug.LogError("Player_Entity not found");
            return null;
        }
        GameObject go = GameObject.Instantiate(player);
        PlayerEntity playerEntity = go.GetComponent<PlayerEntity>();
        ctx.playerRespository.Add(playerEntity);
        
        return playerEntity;
    }

    public static void DoJump(GameContext ctx,PlayerEntity player)
    {
        float inputKeyIndex = ctx.inputEntity.inputKeyIndex;
        if (ctx.inputEntity.inputKeyIndex != 0)
        {
            player.rb.DOJump(player.rb.position+ new Vector2(player.step.x*inputKeyIndex, player.step.y), player.jumpForce, 1, 0.15f);
            inputKeyIndex = 0;
            Debug.Log("DoJump");
        }
    }

}