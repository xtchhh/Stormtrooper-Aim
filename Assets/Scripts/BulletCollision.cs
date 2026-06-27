using UnityEngine;
using UnityEngine.AI;

public class BulletCollision : MonoBehaviour
{
    public GameObject rebel;
    public GameObject stormTrooper;
    public AudioSource death;
    public AudioSource rebelDeath;
    public Animator animator;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

        if (collision.collider.CompareTag("Rebel"))
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
