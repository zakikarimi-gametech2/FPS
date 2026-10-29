using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float chaseRange = 5.0f;

    float distanceToTarget = Mathf.Infinity;

    private bool isProvoked = false;

    NavMeshAgent nma;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked)
        {
            EngageTarget(); 
        }

        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            
        }
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= nma.stoppingDistance)
        {
            ChaseTarget();
        }

        if(distanceToTarget <= nma.stoppingDistance)
        {
            AttackTarget(); 
        }
    }

    private void ChaseTarget()
    {
        nma.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        // Temp for now to show that the enemy is attacking
        print(name + " is attacking " + target.name);
    }

    void OnDrawGizmosSelected()
    {
        // Display the chase radius when selected
        Gizmos.color = Color.red; // Choose
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }


}
