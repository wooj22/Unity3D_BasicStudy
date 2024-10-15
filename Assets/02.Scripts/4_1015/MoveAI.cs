using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 0.1초마다 호출
        InvokeRepeating(nameof(MoveAgent), 0, 0.1f);
    }

    void MoveAgent()
    {
        // 에이전트의 목표 지점과 goal의 위치가 다르다면
        if(agent.destination != goal.position)
        {
            // 목표 지점을 goal의 위치로 변경
            agent.SetDestination(goal.position);
        }
    }
}
