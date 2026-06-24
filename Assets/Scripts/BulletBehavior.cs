using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Analytics.IAnalytic;

public class BulletBehavior : MonoBehaviour
{
    public GameObject bullet;
    public GameObject crosshair;
    public Camera playerCamera;
    public Transform bulletSpawn;
    public float bulletSpeed;

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

    public void Bullet()
    {
        /*
        if (Physics.Raycast(crosshair.transform.position, crosshair.transform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(crosshair.transform.position, crosshair.transform.forward, Color.red);
            Debug.Log($"You are colliding at " + hit.point);
            Vector3 directionToObject = (hit.point - bullet.transform.position).normalized;
            bullet.transform.rotation = Quaternion.LookRotation(directionToObject);

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                var tempBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.rotation);
                tempBullet.GetComponent<Rigidbody>().linearVelocity = bulletSpawn.transform.forward * bulletSpeed;
            }
        }
        */

        if (Physics.Raycast(crosshair.transform.position, crosshair.transform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(crosshair.transform.position, crosshair.transform.forward, Color.blue);
            Debug.Log($"You are colliding at " + hit.point);
            Debug.Log(hit.distance);

            Vector3 directionToObject = (hit.point - bulletSpawn.position).normalized;
            bulletSpawn.rotation = Quaternion.LookRotation(directionToObject);

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                var tempBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                tempBullet.GetComponent<Rigidbody>().linearVelocity = bulletSpawn.forward * bulletSpeed;
            }
        }
    }

    void BulletRotation()
    {
        /*
        //Bullet Spawn Rotation
        Vector3 forwardDirection = playerCamera.transform.forward;
        bulletSpawn.rotation = Quaternion.LookRotation(forwardDirection);
        */
    }
}
