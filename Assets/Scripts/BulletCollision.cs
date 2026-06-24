using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BulletCollision : MonoBehaviour
{
    private GameObject rebel;

    void Start()
    {
        rebel = GameObject.Find("Rebel Idle");
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"You are colliding");
        Destroy(this.gameObject);

        if (collision.gameObject.name == "Rebel Idle")
        {
            Destroy(rebel);
            Debug.Log($"Rebel Killed");
        }
    }
}
