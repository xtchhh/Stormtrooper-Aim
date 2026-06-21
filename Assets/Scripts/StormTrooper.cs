using UnityEngine;
using UnityEngine.InputSystem;

public class StormTrooper : MonoBehaviour
{
    public Camera playercamera;
    public ThirdPersonActions playeractions;
    public float moveSpeed;
    private Vector2 move;
    private Vector3 forward;

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

        forward = playercamera.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = playercamera.transform.right;

        Vector3 relativeForwardInput = forward * cameraFrontDirection;
        Vector3 relativeSideInput = right * cameraSideDirection;

        Vector3 direction = relativeForwardInput + relativeSideInput;

        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    void LookRot()
    {
        this.transform.rotation = Quaternion.LookRotation(forward);
    }
}
