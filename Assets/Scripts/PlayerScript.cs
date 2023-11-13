using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 moveDirection;
    public float moveSpeed = 4f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            Debug.Log(Vector3.Normalize(moveDirection));
            Debug.Log(moveDirection.normalized);
            rigidbody.AddForce(Vector3.Normalize(moveDirection) * Time.fixedDeltaTime 
                * moveSpeed, ForceMode.VelocityChange);
            if(rigidbody.velocity.magnitude > 5)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * 5;
            }
        }
        Debug.Log(rigidbody.velocity);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input != null)
        {
            moveDirection = new Vector3(input.x, 0f, input.y);
        }
    }
}
