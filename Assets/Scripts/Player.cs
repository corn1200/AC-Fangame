using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// 플레이어 스크립트
public class Player : MonoBehaviour
{
    // 플레이어 리지드바디
    private Rigidbody rigidbody;

    // 이동 입력 방향, 최종 이동 방향
    private Vector3 moveDirection;
    private Vector3 finalDirection;

    // 시네머신 타겟 오브젝트
    public GameObject CinemachineCameraTarget;

    // 플레이어 모델 오브젝트
    public GameObject PlayerModel;
    public Animator PlayerAnimator;

    // 현재 스피드 텍스트
    public Text CurrentSpeedText;

    // 플레이어 회전 소요 시간, 회전 속도, 목표 회전 각도
    public float rotationSmoothTime = 0.16f;
    public float rotationVelocity;
    public float targetRotation;

    // 가속도, 카메라 상하 시점 제한 각도
    public float moveSpeed = 25f;
    public float currentMaxSpeed;
    public float generalMaxSpeed = 4f;
    public float boostMaxSpeed = 8f;
    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;

    // 시네머신 타겟 오브젝트의 요 피치 각
    public float cinemachineTargetYaw;
    public float cinemachineTargetPitch;

    void Start()
    {
        // 리지드바디 컴포넌트 할당
        rigidbody = GetComponent<Rigidbody>();
        // 스크린에 커서 고정 설정
        Cursor.lockState = CursorLockMode.Locked;
        currentMaxSpeed = generalMaxSpeed;
    }

    void FixedUpdate()
    {
        // 플레이어 이동 수행
        Move();

        // 현재 속도 표시
        CurrentSpeedText.text = "current speed: " + rigidbody.velocity.magnitude;
    }

    // 이동 입력 함수
    public void OnMove(InputAction.CallbackContext context)
    {
        // 입력 받은 이동 벡터
        Vector2 input = context.ReadValue<Vector2>();

        // 이동 벡터 저장
        moveDirection = new Vector3(input.x, 0f, input.y);
    }

    // 시점 전환 함수
    public void OnLook(InputAction.CallbackContext context)
    {
        // 입력 받은 시점 벡터
        Vector2 lookDirection = context.ReadValue<Vector2>();

        // 시점 벡터의 크기 제곱근이 0.01 이상일 경우 실행
        if (lookDirection.sqrMagnitude >= 0.01f)
        {
            // 시네머신 목표 각도에 시점 벡터를 더함
            cinemachineTargetYaw += lookDirection.x;
            cinemachineTargetPitch += lookDirection.y;
        }

        // 제한된 시점 각도를 계산
        cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
        cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, BottomClamp, TopClamp);

        // 시네머신 카메라 타겟의 회전을 변경
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
        bool isBoost = context.ReadValueAsButton();
        Debug.Log("OnBoost : " + isBoost);

        if (isBoost)
        {
            currentMaxSpeed = boostMaxSpeed;
        }
    }

    public void OnQuickBoost(InputAction.CallbackContext context)
    {
        Debug.Log("OnQuickBoost : " + context.ReadValueAsButton());

        if (moveDirection == Vector3.zero)
        {
            return;
        }

        // 플레이어 리지드바디를 이동 방향으로 가속
        rigidbody.AddForce(finalDirection.normalized * 4000, ForceMode.Force);

        // 부스트 상태로 전환
        currentMaxSpeed = boostMaxSpeed;
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

    // 시점 제한 함수
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void Move()
    {
        // 이동 입력 방향이 있을 경우 실행
        if (moveDirection != Vector3.zero)
        {
            // 카메라의 Y축 회전 값 할당
            float cameraRotation = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
            // 회전 * 입력 벡터로 최종 이동 방향 생성
            Quaternion eulerRotation = Quaternion.Euler(0, cameraRotation, 0);
            finalDirection = eulerRotation * moveDirection;

            // 플레이어 리지드바디를 이동 방향으로 가속
            rigidbody.AddForce(finalDirection.normalized * (moveSpeed * currentMaxSpeed), ForceMode.Force);

            // 목표 회전 각도 설정
            targetRotation = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg +
                             cameraRotation;

            // 현재 회전 각도 설정
            float rotation = Mathf.SmoothDampAngle(PlayerModel.transform.eulerAngles.y,
                targetRotation, ref rotationVelocity, rotationSmoothTime);

            // 플레이어 모델의 Y축 회전 설정
            PlayerModel.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
        else if (rigidbody.velocity.magnitude < generalMaxSpeed)
        {
            currentMaxSpeed = generalMaxSpeed;
        }
        
        PlayerAnimator.SetBool("isMove", moveDirection != Vector3.zero);
    }
}