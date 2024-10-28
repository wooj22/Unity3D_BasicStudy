using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TraceAI : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] float limitDist = 15f;
    private NavMeshAgent agent;
    private Coroutine traceCo;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        traceCo = StartCoroutine(Tracing());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            StopCoroutine(traceCo);
        }
    }

    IEnumerator Tracing()
    {
        while (true)
        {
            float dist = (playerPos.position - transform.position).magnitude;

            if (dist < 3)
            {
                agent.isStopped = true;
            }
            else if (dist < limitDist)
            {
                agent.isStopped = false;
                agent.SetDestination(playerPos.position);
                Debug.DrawLine(playerPos.position, transform.position, Color.red);
            }
            yield return null;
        }
    }
}
