using UnityEngine;
using UnityEngine.AI;

public class RebelController : MonoBehaviour
{
    public GameObject stormTrooper;
    public NavMeshAgent rebelAI;
    public BulletCollision bulletCollisionScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //bulletCollisionScript = GetComponent<BulletCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //BulletContact();
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
        }
    }

    void BulletContact()
    {
        if (bulletCollisionScript.IsShot())
        {
            Destroy(this.gameObject);
        }
    }
}
