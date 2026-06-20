using UnityEngine;

public class StormTrooper : MonoBehaviour
{
    public Camera playercamera;
    public ThirdPersonActions playeractions;
    public float moveSpeed;
    private Vector2 move;
    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playeractions = new ThirdPersonActions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement()
    {
        move = playeractions.Player.Move.ReadValue<Vector2>();
        float cameraFrontDirection = move.y;
        float cameraSideDirection = move.x;

        Vector3 forward = playercamera.transform.forward;
        Vector3 right = playercamera.transform.right;

        Vector3 relativeForwardInput = forward * cameraFrontDirection;
        Vector3 relativeSideInput = right * cameraSideDirection;
    }
}
