using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ModuleCamera {
    public Camera camera;


    public void Inject(Camera camera) {
        this.camera = camera;
    }

    public void Follow(GameContext ctx, Vector3 targetPos, float dt) {
        Vector3 offset = new Vector3(0, 25, -10);
        Vector3 pos = new Vector3(targetPos.x + offset.x, targetPos.y + offset.y, targetPos.z - 10);
        if (ctx.gameEntity.isWIn) {
            camera.transform.position = Vector3.Lerp(camera.transform.position, pos, dt * 2);
        }else{
            camera.transform.position = Vector3.Lerp(camera.transform.position, pos, dt);
        }
    }
}