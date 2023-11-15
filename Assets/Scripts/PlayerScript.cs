using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rigidbody;

    private Vector3 moveDirection;
    public float moveSpeed = 500f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            rigidbody.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveDirection = new Vector3(input.x, 0f, input.y);
    }

    private void OnMouseDown()
    {
        Debug.Log("shangus1");
        rigidbody.AddForce(transform.forward * moveSpeed);
    }
}