using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private GameObject rebel;
    public GameObject stormTrooper;

    void Start()
    {
        rebel = GameObject.Find("Rebel Idle");
        //stormTrooper = GameObject.Find("Idle");
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.name == "Rebel Idle")
        {
            Destroy(rebel);
            Debug.Log($"Rebel Killed");
        }

        if (collision.gameObject.name == "Idle")
        {
            stormTrooper.SetActive(false);
        }
    }
}
