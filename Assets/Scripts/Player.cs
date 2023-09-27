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
            if (inputDir != Vector3.zero && inputDir != transform.forward)
            {
                isRotate = true;
                targetDir = inputDir;
            }
        } else {
            currentTime += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + (inputDir * moveSpeed * Time.deltaTime));
        if (isRotate)
        {
            currentTime = currentTime >= rotTime ? rotTime : currentTime;

            float t = currentTime / rotTime;
            transform.forward = Vector3.Slerp(startDir, targetDir, t);

            if (currentTime == rotTime)
            {
                isRotate = false;
                startDir = transform.forward;
                currentTime = 0;
            }
        }
    }
}