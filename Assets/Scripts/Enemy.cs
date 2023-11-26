using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    private Rigidbody Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enemy: " + other.gameObject.name);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer != 0)
        {
            Debug.Log("Enemy Stay: " + other.gameObject.name);
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer != 0)
        {
            Debug.Log("Enemy Exit: " + other.gameObject.name);
        }
    }
}