using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Main : MonoBehaviour
{
    Context ctx;
    bool isTearDown = false;
    void Awake()
    {//new
        ctx = new Context();
        ctx.Inject();
        ModuleAssets.Load(ctx.assetsContext);
        Debug.Assert(ctx != null);


        PlayerDomain.Spawn(ctx.gameContext);
        Vector2 spawnPos = Vector2.zero;

        for (int i = 0; i < ctx.gameContext.gameEntity.groundCount; i++)
        {
            int randomDir = Random.Range(0f, 1f) > 0.5f ? 1 : -1;
            spawnPos += new Vector2(ctx.gameContext.gameEntity.step.x * randomDir, ctx.gameContext.gameEntity.step.y);


            if (i != ctx.gameContext.gameEntity.groundCount - 1)
            {
                Vector2 pos = spawnPos - Vector2.up * 2f;
                GroundEntity ground = GroundDomain.Spawn(ctx.gameContext, pos, 0);
                ground.transform.DOMove(ground.transform.position + Vector3.up * 2f, 0.5f).SetDelay(0.1f * i);

            }
            else
            {//goals
                Vector2 pos = spawnPos - Vector2.up * 2f;
                GroundEntity goal = GroundDomain.Spawn(ctx.gameContext, pos, 1);
                goal.transform.DOMove(goal.transform.position + Vector3.up * 2f, 0.5f).SetDelay(0.1f * i);


            }


        }


    }



    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        ref float restFixTime = ref ctx.gameContext.gameEntity.restFixTime;

        restFixTime += dt;
        const float FIX_INTERVAL = 0.2f;

        if (restFixTime <= FIX_INTERVAL)
        {

            LogicFix(ctx, FIX_INTERVAL);

            restFixTime = 0;
        }
        else
        {
            while (restFixTime >= FIX_INTERVAL)
            {
                LogicFix(ctx, FIX_INTERVAL);
                restFixTime -= FIX_INTERVAL;
            }
        }

    }

    void LogicFix(Context ctx, float dt)
    {

        ctx.gameContext.inputEntity.Process();

        // player
        int len = ctx.gameContext.playerRespository.TakeAll(out PlayerEntity[] players);
        for (int i = 0; i < len; i++)
        {
            PlayerEntity player = players[i];
            PlayerDomain.DoJump(ctx.gameContext, player, dt);
        }
        // ground
        int groundLen = ctx.gameContext.groundRespository.TakeAll(out GroundEntity[] grounds);
        for (int i = 0; i < groundLen; i++)
        {
            GroundEntity ground = grounds[i];
        }

    }
    void OnDestory()
    {
        TearDown();
    }

    void OnApplicationQuit()
    {
        TearDown();
    }

    void TearDown()
    {
        if (isTearDown)
        {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assetsContext);
    }
}
