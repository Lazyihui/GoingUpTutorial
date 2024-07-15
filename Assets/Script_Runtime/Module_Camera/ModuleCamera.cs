using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ModuleCamera {
    public Camera camera;


    public void Inject(Camera camera) {
        this.camera = camera;
    }

    public void Follow(Vector3 targetPos,float dt) {
        Vector3 offset = camera.transform.position - targetPos;
        Vector2 TargetCameraPos = targetPos + offset;
        camera.transform.position = new Vector3(TargetCameraPos.x, TargetCameraPos.y, camera.transform.position.z);
    }
}