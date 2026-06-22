using UnityEngine;
using UnityEngine.AI;

public class RebelController : MonoBehaviour
{
    public GameObject stormTrooper;
    public NavMeshAgent rebelAI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, stormTrooper.transform.position);

        rebelAI.SetDestination(stormTrooper.transform.position);
    }
}
