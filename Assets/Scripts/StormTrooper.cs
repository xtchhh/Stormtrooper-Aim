using UnityEngine;
using UnityEngine.InputSystem;

public class StormTrooper : MonoBehaviour
{
    public Camera playercamera;
    public ThirdPersonActions playeractions;
    public float moveSpeed;
    private Vector2 move;
    private Vector3 relativeForwardInput;
    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    }

    void Movement()
    {
        move = playeractions.Player.Move.ReadValue<Vector2>();
        float cameraFrontDirection = move.y;
        float cameraSideDirection = move.x;

        Vector3 forward = playercamera.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = playercamera.transform.right;

        relativeForwardInput = forward * cameraFrontDirection;
        Vector3 relativeSideInput = right * cameraSideDirection;

        direction = relativeForwardInput + relativeSideInput;

        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    void LookRot()
    {
        if (move.sqrMagnitude > 0.1)
        {
            this.transform.rotation = Quaternion.LookRotation(relativeForwardInput);
        }
    }
}
