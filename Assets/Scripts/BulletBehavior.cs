using UnityEngine;
using UnityEngine.InputSystem;

public class BulletBehavior : MonoBehaviour
{
    public GameObject bullet;
    public Camera playerCamera;
    public Transform bulletSpawn;
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
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var tempBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            tempBullet.GetComponent<Rigidbody>().linearVelocity = bulletSpawn.transform.forward * 30;
        }
    }

    void BulletRotation()
    {
        Vector3 forwardDirection = playerCamera.transform.forward;
        bulletSpawn.rotation = Quaternion.LookRotation(forwardDirection);
    }
}
