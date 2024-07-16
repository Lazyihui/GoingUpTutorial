using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public static class PlayerDomain {
    public static PlayerEntity Spawn(GameContext ctx) {

        bool has = ctx.assetsContext.TryGetEntity("Player_Entity", out GameObject player);
        if (!has) {
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

    public static void DoJump(GameContext ctx, PlayerEntity player, float dt) {
        float inputKeyIndex = ctx.inputEntity.inputKeyIndex;


        if (ctx.inputEntity.inputKeyIndex != 0 && !ctx.inputEntity.animIsPlaying) {
            ctx.inputEntity.animIsPlaying = true;

            var jumpAnim = player.rb.DOJump(player.rb.position + new Vector2(player.step.x * inputKeyIndex, player.step.y), player.jumpForce, 1, 0.2f).
            SetEase(Ease.OutCubic).OnComplete(() => {
                ctx.inputEntity.animIsPlaying = false;
            });
            ctx.inputEntity.animIsPlaying = jumpAnim.IsPlaying();

            ctx.inputEntity.inputKeyIndex = 0;

        }
    }

    public static void TouchGround(GameContext ctx, PlayerEntity player) {
        if (!ctx.inputEntity.animIsPlaying && !ctx.gameEntity.isWIn) {
            if (Physics2D.CircleCast(player.transform.position, 0.2f, Vector2.zero, 0f, player.whatIsCoal)) {
                ctx.gameEntity.isWIn = true;
                Debug.Log("Win" + Time.timeSinceLevelLoad);
            }
            if (Physics2D.CircleCast(player.transform.position, 0.2f, Vector2.zero, 0f)) {
            }
        }
    }

}