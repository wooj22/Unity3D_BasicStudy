using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    // AI 순찰
    public List<Transform> wayPoints;
    public int nextIndex;
    NavMeshAgent agent;

    // AI value
    float patrolSpeed = 1.5f;
    float traceSpeed = 4f;

    // Condition values
    bool patrolling;
    Vector3 traceTarget;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 순찰 지점 get
        GameObject group = GameObject.Find("WayPointGroup");
        if(group != null)
        {
            group.GetComponentsInChildren(wayPoints);
            wayPoints.RemoveAt(0);

            nextIndex = Random.Range(0, wayPoints.Count);
        }

        SetPatrolling(true);    // 순찰 set
    }

    private void Update()
    {
        // 순찰 상태가 아니라면 리턴
        if (!patrolling) return;

        // 목적지 도착 - 속도, 거리 계산
        if(agent.velocity.magnitude > 0.2f &&
            agent.remainingDistance < 0.5f)
        {
            nextIndex = Random.Range(0, wayPoints.Count);
            MoveWayPoint();
        }
    }

    /// 순찰 이동
    void MoveWayPoint()
    {
        if (agent.isPathStale) return;  // 계산된 경로가 유효하지 않다면 중단
        agent.destination = wayPoints[nextIndex].position;
        agent.isStopped = false;
    }

    /// 추적 이동
    void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale) return;
        agent.destination = pos;
        agent.isStopped = false;
    }

    /// 순찰 지정
    public void SetPatrolling(bool patrol)
    {
        patrolling = patrol;
        agent.speed = patrolSpeed;
        agent.angularSpeed = 120f;
        MoveWayPoint();
    }

    /// 추적 지정
    public void SetTraceTarget(Vector3 pos)
    {
        traceTarget = pos;
        agent.speed = traceSpeed;
        agent.angularSpeed = 360f;
        TraceTarget(traceTarget);
    }

    /// 이동 속력 get
    public float GetSpeed()
    {
        return agent.velocity.magnitude;
    }

    /// 정지
    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        patrolling = false;
    }
}
