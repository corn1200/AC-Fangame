using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 플레이어 리지드 바디, 모델 트랜스 폼
    public Rigidbody PlayerRigidBody;
    public Transform PlayerModelTransform;
    // 입력 방향
    public Vector3 InputDirection;
    // 이동 속도, 점프력, 모델 회전 속도
    public float MoveSpeed = 100.0f;
    public float JumpForth = 100.0f;
    public float RotationSpeed = 20f; 
    public float YVelocity = 0.0f;

    private void Update()
    {
        // 입력이 있을 경우만 실행
        if (InputDirection != Vector3.zero)
        {
            // 방향을 각도로 변환
            float targetAngle = Mathf.Atan2(InputDirection.x, InputDirection.z) * Mathf.Rad2Deg;

            // SmoothDampAngle을 사용해 부드럽게 회전
            float angle = Mathf.SmoothDampAngle(PlayerModelTransform.eulerAngles.y, targetAngle, 
                ref YVelocity, RotationSpeed * Time.deltaTime);

            // 회전 적용
            PlayerModelTransform.eulerAngles = new Vector3(0, angle, 0);
        }
    }

    private void FixedUpdate()
    {
        // 입력 방향으로 힘 가함
        PlayerRigidBody.AddForce(InputDirection * MoveSpeed);
    }

    public void OnInputDir(InputAction.CallbackContext context)
    {
        // 입력 받기
        Vector2 input = context.ReadValue<Vector2>();

        // 입력 방향 저장
        InputDirection = new Vector3(input.x, 0f, input.y).normalized;
    }
    
    public void OnJump()
    {
        // 점프 방향
        Vector3 jumpDir = new Vector3(0f, 1, 0f);
        
        // 점프 방향으로 힘을 가함
        PlayerRigidBody.AddForce(jumpDir * JumpForth);
    }
}