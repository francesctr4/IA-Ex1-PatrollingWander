using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshWander : MonoBehaviour
{
    // Animation parameters
    private Animator animator;

    // NavMesh parameters
    private NavMeshAgent agent;
    public LayerMask navMeshLayer;

    // Wandering parameters
    private Vector3 destinationPoint;
    private bool walkpointSet;
    public float range;

    // Time parameters
    private float waitingTime; 
    private float actualTime; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        waitingTime = 2f;
        actualTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Wander();
    }

    void Wander()
    {
        if (!walkpointSet)
        {
            SearchForDestination();
        }

        if (walkpointSet)
        {
            agent.SetDestination(destinationPoint);
        }

        if (Vector3.Distance(transform.position, destinationPoint) < 0.2)
        {
            animator.SetBool("IsWalking", false);

            actualTime += Time.deltaTime;

            if (actualTime > waitingTime)
            {
                animator.SetBool("IsWalking", true);
                walkpointSet = false;
                
                actualTime = 0f;
            }
        }

    }

    void SearchForDestination()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destinationPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destinationPoint, Vector3.down, navMeshLayer))
        {
            walkpointSet = true;
        }
    }

}
