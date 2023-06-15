using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAZombie : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    
    public int pv = 200;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}