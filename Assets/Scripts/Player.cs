using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    public Vector3 dir = Vector3.zero;
    public float rotSpeed = 40;
    public float moveSpeed = 4;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();

        Debug.Log(dir.ToString());
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
        }
        rigidbody.MovePosition(this.gameObject.transform.position + 
            dir * moveSpeed * Time.deltaTime);
    }
}