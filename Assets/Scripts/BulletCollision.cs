using UnityEngine;
using UnityEngine.AI;

public class BulletCollision : MonoBehaviour
{
    private GameObject rebel;
    public GameObject rebelRagdoll;
    public GameObject stormTrooper;
    public AudioSource death;
    public AudioSource rebelDeath;
    public Animator animator;

    void Start()
    {
        rebel = GameObject.Find("Rebel Idle");
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.name == "Rebel Idle")
        {
            Destroy(rebel);
            rebelDeath.Play();
            Debug.Log($"Rebel Killed");
        }

        if (collision.gameObject.name == "Idle")
        {
            stormTrooper.SetActive(false);
            death.Play();
        }
    }
}
