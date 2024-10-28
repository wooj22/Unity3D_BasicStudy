using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackAI : MonoBehaviour
{ 
    [SerializeField] GameObject player;
    [SerializeField] float limitDist = 5;
    [SerializeField] GameObject bulletPrefab;
    private NavMeshAgent agent;
    private Coroutine attackCo;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        attackCo = StartCoroutine(Attacking());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            StopCoroutine(attackCo);
        }
    }

    IEnumerator Attacking()
    {
        while (true)
        {
            float dist = (player.transform.position - this.transform.position).magnitude;

            if(dist < limitDist)
            {
                this.gameObject.transform.LookAt(player.transform.position);
                Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            }

            yield return new WaitForSeconds(3f);
        }
    }

}
