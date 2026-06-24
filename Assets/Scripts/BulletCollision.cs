using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BulletCollision : MonoBehaviour
{
    public LayerMask layermask;
    public GameObject rebel;
    
    // Update is called once per frame
    void Update()
    {/*
        if (IsShot())
        {
            Destroy(this.gameObject);
        }
        */
    }

    public bool IsShot()
    {
        if (Physics.Raycast(transform.position, transform.forward, 1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Debug.Log($"Collided");
        if (collision.gameObject.name == "Rebel Idle")
        {
            Destroy(rebel);
        }
    }
}
