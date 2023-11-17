using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 8);
    }
}