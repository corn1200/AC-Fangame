using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    public GameObject BoostFire;
    public GameObject BoostLight;
    public Vector3 startDir;
    public Vector3 targetDir = Vector3.zero;
    public Vector3 inputDir = Vector3.zero;
    public float rotTime = 0.1f;
    public float currentRotTime = 0;
    public float moveSpeed = 20;
    public float boostSpeed = 40;
    public float quickBoostSpeed = 20;
    public float jumpSpeed = 20;
    public bool isRotate = false;
    public bool isBoost = false;

    #region dash
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    #endregion

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        startDir = this.transform.forward;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        SetInputDir();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            BoostOn();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            BoostOn();
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
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
        if (isDashing)
        {
            return;
        }

        if (inputDir == Vector3.zero)
        {
            BoostOff();
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

    void BoostOn()
    {
        isBoost = true;
        BoostFire.SetActive(true);
        BoostLight.SetActive(true);
    }

    void BoostOff()
    {
        isBoost = false;
        BoostFire.SetActive(false);
        BoostLight.SetActive(false);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rigidbody.useGravity = false;
        rigidbody.velocity = transform.forward * dashingPower;
        yield return new WaitForSeconds(dashingTime);
        rigidbody.useGravity = true;
        isDashing = false;
        rigidbody.velocity = transform.forward;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}