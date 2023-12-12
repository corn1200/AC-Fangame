using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// 플레이어 스크립트
public class Player : MonoBehaviour
{
    // 플레이어 리지드바디
    private Rigidbody rigidbody;
    // 이동 입력 방향
    private Vector3 moveDirection;

    // 시네머신 타겟 오브젝트
    public GameObject CinemachineCameraTarget;
    // 플레이어 모델 오브젝트
    public GameObject PlayerModel;
    // 현재 스피드 텍스트
    public Text CurrentSpeedText;

    // 플레이어 회전 소요 시간, 회전 속도, 목표 회전 각도
    public float rotationSmoothTime = 0.16f;
    public float rotationVelocity;
    public float targetRotation;
    
    // 가속도, 카메라 상하 시점 제한 각도
    public float moveSpeed = 100f;
    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;

    // 시네머신 타겟 오브젝트의 요 피치 각
    public float cinemachineTargetYaw;
    public float cinemachineTargetPitch;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            float cameraRotation = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
            Quaternion eulerRotation = Quaternion.Euler(0, cameraRotation, 0);
            Vector3 finalDirection = eulerRotation * moveDirection;

            rigidbody.AddForce(finalDirection.normalized * moveSpeed, ForceMode.Force);

            if (rigidbody.velocity.magnitude > 4)
            {
                rigidbody.velocity = finalDirection.normalized * 4;
            }

            targetRotation = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg +
                             cameraRotation;
            
            float rotation = Mathf.SmoothDampAngle(PlayerModel.transform.eulerAngles.y, 
                targetRotation, ref rotationVelocity, rotationSmoothTime);

            PlayerModel.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }

        CurrentSpeedText.text = "current speed: " + rigidbody.velocity.magnitude;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        moveDirection = new Vector3(input.x, 0f, input.y);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookDirection = context.ReadValue<Vector2>();

        if (lookDirection.sqrMagnitude >= 0.01f)
        {
            cinemachineTargetYaw += lookDirection.x;
            cinemachineTargetPitch += lookDirection.y;
        }

        cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
        cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, BottomClamp, TopClamp);

        CinemachineCameraTarget.transform.rotation =
            Quaternion.Euler(cinemachineTargetPitch, cinemachineTargetYaw, 0.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Player: " + other.gameObject.name);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer != 0)
        {
            Debug.Log("Player Stay: " + other.gameObject.name);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer != 0)
        {
            Debug.Log("Player Exit: " + other.gameObject.name);
        }
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

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}