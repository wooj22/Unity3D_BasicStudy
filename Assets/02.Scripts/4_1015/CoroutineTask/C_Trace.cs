using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// 추적 AI : 추적 가능 범위 내에서 플레이어를 쫒아감
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
            // 플레이어 거리 계산
            float dist = (playerPos.position - this.transform.position).magnitude;

            if (dist < 3)    // 가까우면 정지
            {
                agent.isStopped = true;
            }
            else if (dist < limitDist)   // 추적가능 거리 내에 있으면 추적
            {
                agent.isStopped = false;
                Debug.DrawLine(playerPos.position, this.transform.position, Color.blue);
                agent.SetDestination(playerPos.position);
            }
        }
    }
}
