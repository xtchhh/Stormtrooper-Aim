using UnityEngine;
using UnityEngine.InputSystem;

public class CrossHair : MonoBehaviour
{
    public GameObject rotatePoint;
    public float rotateSpeed;
    public Camera playercamera;

    // Update is called once per frame
    void Update()
    {
        Crosshair();
        CrossHairRotation();
    }

    void Crosshair()
    {
        transform.RotateAround(rotatePoint.transform.position, transform.forward, rotateSpeed * Time.deltaTime);
    }

    void CrossHairRotation()
    {

        
        Vector3 forwardDirection = playercamera.transform.forward;
        transform.localRotation = Quaternion.LookRotation(forwardDirection);
    }
}
