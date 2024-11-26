using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    // AI ����
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

        // ���� ���� get
        GameObject group = GameObject.Find("WayPointGroup");
        if(group != null)
        {
            group.GetComponentsInChildren(wayPoints);
            wayPoints.RemoveAt(0);

            nextIndex = Random.Range(0, wayPoints.Count);
        }

        SetPatrolling(true);    // ���� set
    }

    private void Update()
    {
        // ���� ���°� �ƴ϶�� ����
        if (!patrolling) return;

        // ������ ���� - �ӵ�, �Ÿ� ���
        if(agent.velocity.magnitude > 0.2f &&
            agent.remainingDistance < 0.5f)
        {
            nextIndex = Random.Range(0, wayPoints.Count);
            MoveWayPoint();
        }
    }

    /// ���� �̵�
    void MoveWayPoint()
    {
        if (agent.isPathStale) return;  // ���� ��ΰ� ��ȿ���� �ʴٸ� �ߴ�
        agent.destination = wayPoints[nextIndex].position;
        agent.isStopped = false;
    }

    /// ���� �̵�
    void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale) return;
        agent.destination = pos;
        agent.isStopped = false;
    }

    /// ���� ����
    public void SetPatrolling(bool patrol)
    {
        patrolling = patrol;
        agent.speed = patrolSpeed;
        agent.angularSpeed = 120f;
        MoveWayPoint();
    }

    /// ���� ����
    public void SetTraceTarget(Vector3 pos)
    {
        traceTarget = pos;
        agent.speed = traceSpeed;
        agent.angularSpeed = 360f;
        TraceTarget(traceTarget);
    }

    /// �̵� �ӷ� get
    public float GetSpeed()
    {
        return agent.velocity.magnitude;
    }

    /// ����
    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        patrolling = false;
    }
}
