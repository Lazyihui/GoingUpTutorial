using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        ref float restFixTime = ref ctx.gameContext.gameEntity.restFixTime;

        restFixTime += dt;
        const float FIX_INTERVAL = 0.2f;

        if (restFixTime <= FIX_INTERVAL) {

            LogicFix(ctx, FIX_INTERVAL);

            restFixTime = 0;
        } else {
            while (restFixTime >= FIX_INTERVAL) {
                LogicFix(ctx, FIX_INTERVAL);
                restFixTime -= FIX_INTERVAL;
            }
        }

    }

    void LogicFix(Context ctx, float dt)
    {

        ctx.gameContext.inputEntity.Process();

        // player
        int len = ctx.gameContext.playerRespository.TakeAll(out  PlayerEntity[] players);
        for (int i = 0; i < len; i++)
        {
            PlayerEntity player = players[i];
            PlayerDomain.DoJump(ctx.gameContext, player);
        }
    }
      void OnDestory() {
        TearDown();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assetsContext);
    }
}
