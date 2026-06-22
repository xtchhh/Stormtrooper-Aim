using UnityEngine;
using UnityEngine.InputSystem;

public class CrossHair : MonoBehaviour
{
    public GameObject point;
    public float rotateSpeed;
    public Camera playercamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bullet();
        BulletRotation();
    }

    void Bullet()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red * 5f);
        transform.RotateAround(point.transform.position, transform.forward, rotateSpeed * Time.deltaTime);

        if (IsShot() && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log($"Killed");
        }
        else
        {
            Debug.Log($"Missed");
        }
    }

    void BulletRotation()
    {
        Vector3 forwardDirection = playercamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(forwardDirection);
    }

    public bool IsShot()
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
