using UnityEngine;
using UnityEngine.InputSystem;

public class CrossHair : MonoBehaviour
{
    public GameObject point;
    public Camera playerCamera;
    public float rotateSpeed;

    void Update()
    {
        Bullet();
    }

    void Bullet()
    {
        Vector3 forward = playerCamera.transform.forward;

        this.transform.rotation = Quaternion.LookRotation(forward);
        point.transform.rotation = Quaternion.LookRotation(forward);

        Debug.DrawRay(transform.position, transform.forward, Color.red * 5f);
        transform.RotateAround(point.transform.position, transform.forward, rotateSpeed * Time.deltaTime);

        if (InSight() && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log($"Killed");
        }
        else
        {
            Debug.Log($"Missed");
        }
    }

    public bool InSight()
    {
        if (Physics.Raycast(transform.position, transform.forward, 50f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
