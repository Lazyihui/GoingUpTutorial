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
        playerEntity.id = ctx.gameEntity.playerID++;
        ctx.playerRespository.Add(playerEntity);

        return playerEntity;
    }

    public static void DoJump(GameContext ctx, PlayerEntity player, float dt)
    {
        float inputKeyIndex = ctx.inputEntity.inputKeyIndex;


        if (ctx.inputEntity.inputKeyIndex != 0 && !ctx.inputEntity.animIsPlaying)
        {
            ctx.inputEntity.animIsPlaying = true;

            var jumpAnim = player.rb.DOJump(player.rb.position + new Vector2(player.step.x * inputKeyIndex, player.step.y), player.jumpForce, 1, 0.2f).
            SetEase(Ease.OutCubic).OnComplete(() =>
            {
                ctx.inputEntity.animIsPlaying = false;
            });
            ctx.inputEntity.animIsPlaying = jumpAnim.IsPlaying();
            // player.intervalTimer -= dt;
            // if (player.intervalTimer <= 0)
            // {
            //     Debug.Log("DoJump");


            //     ctx.inputEntity.animIsPlaying = false;
            //     player.intervalTimer = player.interval;
            // }

            ctx.inputEntity.inputKeyIndex = 0;

        }
    }

}