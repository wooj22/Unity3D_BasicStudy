using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// 순찰 AI : 목표지점을 움직여다님
public class Patrol : MonoBehaviour
{
    public Transform[] goal;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(MoveAgent), 0, 0.1f);
    }

    void MoveAgent()
    {
        if(agent.remainingDistance < 0.5f)
        {
            int index = Random.Range(0, goal.Length);
            agent.SetDestination(goal[index].position);
        }
    }
}
