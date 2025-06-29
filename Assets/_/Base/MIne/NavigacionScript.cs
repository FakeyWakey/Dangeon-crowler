using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class NavigacionScript : MonoBehaviour
{
    public Transform enemy;
    private NavMeshAgent agent;
    public List<Transform> PatrolPoints = new List<Transform>();
    public int PatrolPointCounter;
    
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        agent.destination = PatrolPoints[PatrolPointCounter].position;
        if (Vector3.Distance(transform.position, agent.destination)< 1f) //jeœli jest 0.1 away from the point zalicza punkt
        {
            PatrolPointCounter++;
            if (PatrolPointCounter >= PatrolPoints.Count)
            { 
                PatrolPointCounter = 0;
            }
        } 

    }
}
