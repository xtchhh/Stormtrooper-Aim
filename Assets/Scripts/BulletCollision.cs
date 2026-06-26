using UnityEngine;
using UnityEngine.AI;

public class BulletCollision : MonoBehaviour
{
    private GameObject rebel;
    public GameObject rebelRagdoll;
    public GameObject stormTrooper;
    public AudioSource death;
    public Animator animator;

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
            rebelRagdoll.SetActive(true);
            Debug.Log($"Rebel Killed");
        }

        if (collision.gameObject.name == "Idle")
        {
            stormTrooper.SetActive(false);
            death.Play();
        }
    }
}
