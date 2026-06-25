using UnityEngine;
using UnityEngine.InputSystem;

public class BulletBehavior : MonoBehaviour
{
    public GameObject bullet;
    public GameObject crosshair;
    public Camera playerCamera;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public AudioSource e11;

    void Update()
    {
        Bullet();
    }

    void Bullet()
    {
        //Ray ray = playerCamera.ScreenPointToRay();
        if (Physics.Raycast(crosshair.transform.position, crosshair.transform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(crosshair.transform.position, crosshair.transform.forward, Color.blue);
            Debug.Log($"You are colliding at " + hit.point);
            Debug.Log(hit.distance);

            Vector3 directionToObject = (hit.point - bulletSpawn.position).normalized;
            bulletSpawn.rotation = Quaternion.LookRotation(directionToObject);

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                e11.Play();
                var tempBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                tempBullet.GetComponent<Rigidbody>().linearVelocity = bulletSpawn.forward * bulletSpeed;
            }
        }
    }
}
