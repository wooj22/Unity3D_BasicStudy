using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// ���� AI : ���� ���� ���� ������ �÷��̾ �i�ư�
public class Trace : MonoBehaviour
{
    [SerializeField] float limitDist;     //���� ���� �Ÿ�
    [SerializeField] Transform playerPos;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // �÷��̾� ã��
        GameObject player = GameObject.FindWithTag("Player");
        playerPos = player.transform;

        // ����
        InvokeRepeating(nameof(MoveAgent), 0, 0.5f);
    }

    private void MoveAgent()
    {
        // �÷��̾� �Ÿ� ���
        float dist = (playerPos.position - this.transform.position).magnitude;

        if(dist < 3)    // ������ ����
        {
            agent.isStopped = true;     
        }
        else if(dist < limitDist)   // �������� �Ÿ� ���� ������ ����
        {
            agent.isStopped = false;
            Debug.DrawLine(playerPos.position, this.transform.position, Color.blue);
            agent.SetDestination(playerPos.position);
        }       
    }
}
