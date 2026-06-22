using UnityEngine;
using UnityEngine.InputSystem;

public class CrossHair : MonoBehaviour
{
    public GameObject point;
    public float rotateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bullet();
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
