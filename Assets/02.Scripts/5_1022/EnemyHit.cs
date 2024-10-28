using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHit : MonoBehaviour
{
    private Material mat;
    private Rigidbody rb;
    private NavMeshAgent agent;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mat.color = Color.blue;
            Invoke(nameof(RecoverColor), 0.2f);

        }
        
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Die();
        }
    }

    void RecoverColor()
    {
        mat.color = Color.magenta;
    }

    private void Die()
    {
        agent.enabled = false;
        mat.color = Color.black;

        rb.isKinematic = false;
        rb.maxAngularVelocity = 100;
        rb.velocity = Vector3.up * 10f;
        rb.angularVelocity = Vector3.one * 10f;

        Destroy(this.gameObject, 3f);
    }
}
