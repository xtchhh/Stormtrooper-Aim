using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StormTrooper : MonoBehaviour
{
    public Camera playercamera;
    public ThirdPersonActions playeractions;
    public CharacterController stormActions;
    public Animator animator;
    public float moveSpeed;
    public float velocity;
    private Vector2 move;
    private Vector3 forward;

    void Awake()
    {
        playeractions = new ThirdPersonActions();
    }

    void OnEnable()
    {
        playeractions.Enable();
    }

    void OnDisable()
    {
        playeractions.Disable();
    }

    void Update()
    {
        Movement();
        LookRot();
        Gravity();
        SimpleAnim();
    }

    void Movement()
    {
        move = playeractions.Player.Move.ReadValue<Vector2>();
        float cameraFrontDirection = move.y;
        float cameraSideDirection = move.x;

        forward = playercamera.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = playercamera.transform.right;

        Vector3 relativeForwardInput = forward * cameraFrontDirection;
        Vector3 relativeSideInput = right * cameraSideDirection;

        Vector3 direction = relativeForwardInput + relativeSideInput + new Vector3(0, velocity, 0);

        stormActions.Move(direction * moveSpeed * Time.deltaTime);
    }

    void LookRot()
    {
        stormActions.transform.rotation = Quaternion.LookRotation(forward);
    }

    void Gravity()
    {
        if (!stormActions.isGrounded)
        {
            velocity -= 9.81f * Time.deltaTime;
        }
        else
        {
            velocity = 0f;
        }
    }

    void SimpleAnim()
    {
        if (playeractions.Player.Move.ReadValue<Vector2>().sqrMagnitude > 0.1)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdling", false);
        }
        else
        {
            animator.SetBool("isIdling", true);
            animator.SetBool("isWalking", false);
        }
    }
}