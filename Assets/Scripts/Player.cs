using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    public Vector3 startDir;
    public Vector3 targetDir = Vector3.zero;
    public Vector3 inputDir = Vector3.zero;
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
        inputDir.x = Input.GetAxis("Horizontal");
        inputDir.z = Input.GetAxis("Vertical");
        inputDir.Normalize();

        Debug.Log(inputDir.ToString());
        if (!isRotate)
        {
            if (inputDir != Vector3.zero)
            {
                isRotate = true;
                targetDir = inputDir;
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
        transform.position += inputDir * moveSpeed * Time.deltaTime;
    }
}