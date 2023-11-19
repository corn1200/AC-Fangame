using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;

    private Vector3 moveDirection;
    public float moveSpeed = 100f;

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

    private void OnMouseDown()
    {
        rigidbody.AddForce(transform.forward * moveSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("collision enter");
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("collision stay");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("collision exit");
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveDirection = new Vector3(input.x, 0f, input.y);
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        Debug.Log("OnBoost : " + context.ReadValueAsButton());
    }
    
    public void OnQuickBoost(InputAction.CallbackContext context)
    {
        Debug.Log("OnQuickBoost : " + context.ReadValueAsButton());
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("OnJump : " + context.ReadValueAsButton());
    }
    
    public void OnAssaultBoost(InputAction.CallbackContext context)
    {
        Debug.Log("OnAssaultBoost : " + context.ReadValueAsButton());
    }
    
    public void OnTargetAssist(InputAction.CallbackContext context)
    {
        Debug.Log("OnTargetAssist : " + context.ReadValueAsButton());
    }
    
    public void OnLeftWeapon(InputAction.CallbackContext context)
    {
        Debug.Log("OnLeftWeapon : " + context.ReadValueAsButton());
    }
    
    public void OnRightWeapon(InputAction.CallbackContext context)
    {
        Debug.Log("OnRightWeapon : " + context.ReadValueAsButton());
    }
    
    public void OnLeftShoulderWeapon(InputAction.CallbackContext context)
    {
        Debug.Log("OnLeftShoulderWeapon : " + context.ReadValueAsButton());
    }
    
    public void OnRightShoulderWeapon(InputAction.CallbackContext context)
    {
        Debug.Log("OnRightShoulderWeapon : " + context.ReadValueAsButton());
    }
    
    public void OnShiftControl(InputAction.CallbackContext context)
    {
        Debug.Log("OnShiftControl : " + context.ReadValueAsButton());
    }
    
    public void OnRepairKit(InputAction.CallbackContext context)
    {
        Debug.Log("OnRepairKit : " + context.ReadValueAsButton());
    }
    
    public void OnAccess(InputAction.CallbackContext context)
    {
        Debug.Log("OnAccess : " + context.ReadValueAsButton());
    }
    
    public void OnScan(InputAction.CallbackContext context)
    {
        Debug.Log("OnScan : " + context.ReadValueAsButton());
    }
    
    public void OnWeaponDisarm(InputAction.CallbackContext context)
    {
        Debug.Log("OnWeaponDisarm : " + context.ReadValueAsButton());
    }
    
    public void OnChoiceLeft(InputAction.CallbackContext context)
    {
        Debug.Log("OnChoiceLeft : " + context.ReadValueAsButton());
    }
    
    public void OnChoiceRight(InputAction.CallbackContext context)
    {
        Debug.Log("OnChoiceRight : " + context.ReadValueAsButton());
    }
}