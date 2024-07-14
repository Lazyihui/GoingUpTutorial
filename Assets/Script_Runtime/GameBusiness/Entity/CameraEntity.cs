using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraEntity : MonoBehaviour {
    Transform target;
    Vector3 offset;

    void Start() {
        target = GameObject.Find("Player_Entity(Clone)").transform;
        offset = transform.position - target.position;
    }

    void LateUpdate() {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, Time.deltaTime);
    }
}