using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] List<Transform> goalPos;
    private NavMeshAgent agent;
    private Coroutine patrolCo;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolCo = StartCoroutine(Patrolling());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            StopCoroutine(patrolCo);
        }
    }

    IEnumerator Patrolling()
    {
        while (true)
        {
            if (agent.remainingDistance < 0.5f)
            {
                int index = Random.Range(0, goalPos.Count);
                agent.SetDestination(goalPos[index].position);
            }
            yield return null;
        }
    }

}
