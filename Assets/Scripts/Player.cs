using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody PlayerRigidBody;
    public Vector3 InputDirection;
    public float MoveSpeed = 100.0f;
    public float JumpForth = 100.0f;

    private void FixedUpdate()
    {
        PlayerRigidBody.AddForce(InputDirection * MoveSpeed);
    }

    public void OnInputDir(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        InputDirection = new Vector3(input.x, 0f, input.y).normalized;
    }
    
    public void OnJump()
    {
        Vector3 jumpDir = new Vector3(0f, 1, 0f);
        
        PlayerRigidBody.AddForce(jumpDir * JumpForth);
    }
}