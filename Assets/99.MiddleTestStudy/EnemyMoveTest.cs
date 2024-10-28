using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTest : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(MoveAgent), 0, 0.1f);
    }

    void MoveAgent()
    {
        agent.SetDestination(playerPos.position);
    }
}
