using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 moveDirection;

    public GameObject CinemachineCameraTarget;
    public GameObject PlayerModel;
    public Text CurrentSpeedText;

    public float moveSpeed = 100f;
    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;

    public float cinemachineTargetYaw;
    public float cinemachineTargetPitch;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        CurrentSpeedText.text = "current speed: " + rigidbody.velocity.magnitude; 
        if (moveDirection != Vector3.zero)
        {
            float cameraRotation = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
            Quaternion eulerRotation = Quaternion.Euler(0, cameraRotation, 0);
            Vector3 finalDirection =  eulerRotation * moveDirection;
            PlayerModel.transform.rotation = eulerRotation;
            rigidbody.AddForce(finalDirection.normalized * moveSpeed, ForceMode.Force);
        }
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