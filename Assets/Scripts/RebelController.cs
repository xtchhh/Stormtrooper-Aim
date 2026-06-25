using UnityEngine;
using UnityEngine.AI;

public class RebelController : MonoBehaviour
{
    public GameObject stormTrooper;
    public NavMeshAgent rebelAI;
    public GameObject rebelBulletSpawn;
    public GameObject bullet;
    public Animator animator;
    public float rebelBulletSpeed;
    public float bulletRate;

    void Start()
    {
        InvokeRepeating(nameof(RebelBullet), 2.0f, bulletRate);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, stormTrooper.transform.position);
        Vector3 directionToPlayer = (stormTrooper.transform.position - this.transform.position).normalized;

        rebelAI.SetDestination(stormTrooper.transform.position);

        if (distanceToPlayer <= rebelAI.stoppingDistance)
        {
            Quaternion lookRot = Quaternion.LookRotation(directionToPlayer);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, lookRot, 8 * Time.deltaTime);
            animator.Play("Rebel Idle");
        }
    }

    void RebelBullet()
    {
        if (this.gameObject != null)
        {
            var tempBullet = Instantiate(bullet, rebelBulletSpawn.transform.position, rebelBulletSpawn.transform.rotation);
            tempBullet.GetComponent<Rigidbody>().linearVelocity = rebelBulletSpawn.transform.forward * rebelBulletSpeed;
        }
    }
}
