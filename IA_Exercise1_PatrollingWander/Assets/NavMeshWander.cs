using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshWander : MonoBehaviour
{
    // public GameObject target;
    Animator animator;
    NavMeshAgent agent;
    public LayerMask navMeshLayer;
    // public LayerMask playerLayer;

    // Wander

    Vector3 destinationPoint;
    bool walkpointSet;
    public float range;

    private float tiempoEspera = 3f; // Tiempo de espera antes de la primera llamada.
    private float tiempoActual = 0f; // Tiempo actual.

    // Start is called before the first frame update
    void Start()
    {
        tiempoEspera = 2f;
        tiempoActual = 0f;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

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

            tiempoActual += Time.deltaTime;

            animator.SetBool("IsWalking", false);

            if (tiempoActual > tiempoEspera)
            {
                tiempoActual = 0f;
                walkpointSet = false;
                animator.SetBool("IsWalking", true);
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
