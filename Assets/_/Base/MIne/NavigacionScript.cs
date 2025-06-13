using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class NavigacionScript : MonoBehaviour
{
    public Transform enemy;
    private NavMeshAgent agent;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        agent.destination = enemy.position;
    }
}
