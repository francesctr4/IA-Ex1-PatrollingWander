using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;

    //Wander
    public float radius;
    public float offset;
    private Vector3 localTarget;
    private Vector3 worldTarget;
    private float tiempoEspera = 3f; // Tiempo de espera antes de la primera llamada.
    private float intervaloTiempo = 5f; // Intervalo de tiempo entre cada llamada.
    private float tiempoActual = 0f; // Tiempo actual.

    // Start is called before the first frame update
    void Start()
    {
        tiempoEspera = 3f;
        intervaloTiempo = 6f;
        tiempoActual = 0f;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //// parameters: float radius, offset;
        //Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        //localTarget += new Vector3(0, 0, offset);

        //Vector3 worldTarget = transform.TransformPoint(localTarget);
        //worldTarget.y = 0f;

        //agent.destination = target.transform.position;

        tiempoActual += Time.deltaTime;


        if (tiempoActual > tiempoEspera)
        {
            tiempoActual = 0f;
            localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;


        }
        agent.destination = worldTarget;

        //agent.destination = target.transform.position;
    }
}
