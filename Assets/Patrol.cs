using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [HideInInspector] public Transform[] Points;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        var target = Points[Random.Range(0, Points.Length)];
        if (!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            agent.destination = target.position;
        }
    }
}
