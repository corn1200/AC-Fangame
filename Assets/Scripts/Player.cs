using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    public GameObject BoostFire;
    public GameObject BoostLight;
    public Vector3 startDir;
    public Vector3 targetDir = Vector3.zero;
    public Vector3 inputDir = Vector3.zero;
    public float rotTime = 0.1f;
    public float currentRotTime = 0;
    public float moveSpeed = 20;
    public float boostSpeed = 40;
    public bool isRotate = false;
    public bool isBoost = false;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        startDir = this.transform.forward;
    }

    void Update()
    {
        SetInputDir();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isBoost = true;
            BoostFire.SetActive(true);
            BoostLight.SetActive(true);
        }

        if (!isRotate)
        {
            SetRotationDir();
        } else {
            UpdateCurrRotTime();
        }
    }

    private void FixedUpdate()
    {
        if (inputDir == Vector3.zero)
        {
            isBoost = false;
            BoostFire.SetActive(false);
            BoostLight.SetActive(false);
        }

        Move();
        if (isRotate)
        {
            Rotate();
        }
    }

    void Move()
    {
        float speed = isBoost ? boostSpeed : moveSpeed;
        rigidbody.MovePosition(transform.position + (inputDir * speed * Time.deltaTime));
    }

    void Rotate()
    {
        currentRotTime = currentRotTime >= rotTime ? rotTime : currentRotTime;

        float t = currentRotTime / rotTime;
        transform.forward = Vector3.Slerp(startDir, targetDir, t);

        if (currentRotTime == rotTime)
        {
            isRotate = false;
            startDir = transform.forward;
            currentRotTime = 0;
        }
    }

    void SetInputDir()
    {
        inputDir.x = Input.GetAxis("Horizontal");
        inputDir.z = Input.GetAxis("Vertical");
        if (inputDir.magnitude > 1)
        {
            inputDir.Normalize();
        }
    }

    void SetRotationDir()
    { 
        if (inputDir != Vector3.zero && inputDir != transform.forward)
        {
            isRotate = true;
            targetDir = inputDir;
        }
    }

    void UpdateCurrRotTime()
    {
        currentRotTime += Time.deltaTime;
    }
}