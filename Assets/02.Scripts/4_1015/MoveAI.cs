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

        // 0.1�ʸ��� ȣ��
        InvokeRepeating(nameof(MoveAgent), 0, 0.1f);
    }

    void MoveAgent()
    {
        // ������Ʈ�� ��ǥ ������ goal�� ��ġ�� �ٸ��ٸ�
        if(agent.destination != goal.position)
        {
            // ��ǥ ������ goal�� ��ġ�� ����
            agent.SetDestination(goal.position);
        }
    }
}
