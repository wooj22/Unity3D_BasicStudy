using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// 추적 AI : 추적 가능 범위 내에서 플레이어를 쫒아감
public class Trace : MonoBehaviour
{
    [SerializeField] float limitDist;     //추적 가능 거리
    [SerializeField] Transform playerPos;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 플레이어 찾기
        GameObject player = GameObject.FindWithTag("Player");
        playerPos = player.transform;

        // 추적
        InvokeRepeating(nameof(MoveAgent), 0, 0.5f);
    }

    private void MoveAgent()
    {
        // 플레이어 거리 계산
        float dist = (playerPos.position - this.transform.position).magnitude;

        if(dist < 3)    // 가까우면 정지
        {
            agent.isStopped = true;     
        }
        else if(dist < limitDist)   // 추적가능 거리 내에 있으면 추적
        {
            agent.isStopped = false;
            Debug.DrawLine(playerPos.position, this.transform.position, Color.blue);
            agent.SetDestination(playerPos.position);
        }       
    }
}
