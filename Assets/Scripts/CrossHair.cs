using UnityEngine;
using UnityEngine.InputSystem;

public class CrossHair : MonoBehaviour
{
    public GameObject rotatePoint;
    private GameObject quadCrosshair;
    public float rotateSpeed;
    public Camera playercamera;
    void Start()
    {
        quadCrosshair = GameObject.Find("Crosshair");
    }


    // Update is called once per frame
    void Update()
    {
        Crosshair();
        CrossHairRotation();
    }

    void Crosshair()
    {
        transform.RotateAround(rotatePoint.transform.position, rotatePoint.transform.forward, rotateSpeed * Time.deltaTime);
    }

    void CrossHairRotation()
    {
        Vector3 forwardDirection = playercamera.transform.forward;
        Vector3 crosshairAngles = this.transform.eulerAngles;

        this.transform.rotation = Quaternion.LookRotation(forwardDirection);
        this.transform.rotation = Quaternion.Euler(crosshairAngles.x, crosshairAngles.y, 0f); //zeroed out axis'

        //Quad Crosshair
        quadCrosshair.transform.position = this.transform.position;
        quadCrosshair.transform.rotation = Quaternion.LookRotation(forwardDirection);

    }
}
