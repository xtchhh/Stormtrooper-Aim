using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StormTrooper : MonoBehaviour
{
    public Camera playercamera;
    public ThirdPersonActions playeractions;
    public float moveSpeed;
    public float aboveTransform;
    public float radius;
    public float maxGroundedDistance;
    public float velocity;
    public AudioSource audioSource;
    private Vector2 move;
    private Vector3 forward;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(PlaySound), 1.0f, 1.0f);
    }

    void Awake()
    {
        playeractions = new ThirdPersonActions();
    }

    void OnEnable()
    {
        playeractions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LookRot();
        //Gravity();
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

        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    void LookRot()
    {
        this.transform.rotation = Quaternion.LookRotation(forward);
    }

    void PlaySound()
    {
        audioSource.Play();
    }

    void Gravity()
    {
        if (IsGrounded())
        {
            velocity = 0f;
            Debug.Log($"Grounded");
        }
        else
        {
            velocity -= 9.81f * Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        if (IsGrounded())
        {
            Gizmos.DrawSphere(transform.position + transform.up * aboveTransform, radius);
        }
    }

    bool IsGrounded()
    {
        if (Physics.SphereCast(transform.position + transform.up * aboveTransform, radius, -transform.up, out RaycastHit hit, maxGroundedDistance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}