using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// ���� AI : ���� ���� ���� ������ �÷��̾ �i�ư�
public class C_Trace : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] float limitDist;
    private NavMeshAgent agent;
    private Coroutine aiCorutine;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        aiCorutine = StartCoroutine(MoveAgent());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StopCoroutine(aiCorutine);
        }
    }

    IEnumerator MoveAgent()
    {
        while (true)
        {
            // �÷��̾� �Ÿ� ���
            float dist = (playerPos.position - this.transform.position).magnitude;

            if (dist < 3)    // ������ ����
            {
                agent.isStopped = true;
            }
            else if (dist < limitDist)   // �������� �Ÿ� ���� ������ ����
            {
                agent.isStopped = false;
                Debug.DrawLine(playerPos.position, this.transform.position, Color.blue);
                agent.SetDestination(playerPos.position);
            }
        }
    }
}
