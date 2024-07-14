using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public static class PlayerDomain
{
    public static PlayerEntity Spawn(GameContext ctx)
    {

        bool has = ctx.assetsContext.TryGetEntity("Player_Entity", out GameObject player);
        if (!has)
        {
            Debug.LogError("Player_Entity not found");
            return null;
        }
        GameObject go = GameObject.Instantiate(player);
        PlayerEntity playerEntity = go.GetComponent<PlayerEntity>();
        playerEntity.Ctor();
        ctx.playerRespository.Add(playerEntity);

        return playerEntity;
    }

    public static void DoJump(GameContext ctx, PlayerEntity player)
    {
        float inputKeyIndex = ctx.inputEntity.inputKeyIndex;


        if (ctx.inputEntity.inputKeyIndex != 0&&!ctx.inputEntity.animIsPlaying)
        {
            Debug.Log(inputKeyIndex);
            player.rb.DOJump(new Vector2(player.step.x * inputKeyIndex, player.step.y), player.jumpForce, 1,0.005f);
            inputKeyIndex = 0;
            ctx.inputEntity.animIsPlaying = true;
            Debug.Log("DoJump");
        }
    }

}