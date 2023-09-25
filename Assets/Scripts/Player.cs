using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    public Vector3 startDir;
    public Vector3 targetDir = Vector3.zero;
    public float rotTime = 0.1f;
    public float currentTime = 0;
    public float moveSpeed = 20;
    public bool isRotate = false;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        startDir = this.transform.forward;
    }

    void Update()
    {
        if (!isRotate)
        {
            targetDir.x = Input.GetAxis("Horizontal");
            targetDir.z = Input.GetAxis("Vertical");
            targetDir.Normalize();

            Debug.Log(targetDir.ToString());

            if (targetDir != Vector3.zero)
            {
                isRotate = true;
            }
        }

        if (isRotate)
        {
            currentTime += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isRotate)
        {
            if (currentTime >= rotTime)
            {
                currentTime = rotTime;
            }

            float t = currentTime / rotTime;
            transform.forward = Vector3.Slerp(startDir, targetDir, t);

            if (currentTime >= rotTime)
            {
                isRotate = false;
                startDir = transform.forward;
                currentTime = 0;
            }
        }
        rigidbody.MovePosition(this.gameObject.transform.position +
            targetDir * moveSpeed * Time.deltaTime);
    }
}