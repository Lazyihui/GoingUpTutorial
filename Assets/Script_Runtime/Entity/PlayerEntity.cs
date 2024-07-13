using System;
using System.Collections;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public int id;
    public int inputKeyIndex;

    public float jumpForce;

    public Vector2 step;

    public void Ctor()
    {
        jumpForce = 2.5f;
    }
}