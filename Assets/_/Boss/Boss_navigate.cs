using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_navigate : MonoBehaviour
{
    public List<Transform> PatrolPoints = new List<Transform>();
    private int PatrolPointCounter = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.1f; // Make sure it's low enough

        if (PatrolPoints.Count > 0)
            agent.destination = PatrolPoints[PatrolPointCounter].position;
        else
            Debug.LogWarning("No patrol points set!");
    }

    void Update()
    {
        if (PatrolPoints.Count == 0 || PatrolPoints[PatrolPointCounter] == null)
            return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            PatrolPointCounter = (PatrolPointCounter + 1) % PatrolPoints.Count;
            agent.destination = PatrolPoints[PatrolPointCounter].position;
        }
    }
}