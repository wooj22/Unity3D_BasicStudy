using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/// 순찰 AI : 목표지점을 움직여다님
public class C_Patrol : MonoBehaviour
{
    [SerializeField] Transform[] goalTrans;
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
            if (agent.remainingDistance < 0.5f)
            {
                int index = Random.Range(0, goalTrans.Length);
                agent.SetDestination(goalTrans[index].position);
            }
        }
    }
}
