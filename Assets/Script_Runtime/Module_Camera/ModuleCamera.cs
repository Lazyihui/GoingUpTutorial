using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ModuleCamera {
    public Camera camera;


    public void Inject(Camera camera) {
        this.camera = camera;
    }

    public void Follow(Vector3 targetPos, float dt) {
        Debug.Log("camera pos: " + camera.transform.position);
        Vector3 offset = new Vector3(0, 25, -10);
        Vector3 pos = new Vector3(targetPos.x + offset.x, targetPos.y + offset.y, targetPos.z - 10);
        camera.transform.position = Vector3.Lerp(camera.transform.position, pos, dt );
    }
}