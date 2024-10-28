using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private Material mat;
    private Rigidbody rb;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            mat.color = Color.black;
            rb.isKinematic = false;
            rb.maxAngularVelocity = 30;
            rb.velocity = Vector3.up * 5;

            Invoke(nameof(RecoverColor), 0.2f);
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            mat.color = Color.red;
            rb.angularVelocity = Vector3.zero;
            Invoke(nameof(RecoverColor), 0.2f);
        }
    }

    void RecoverColor()
    {
        mat.color = Color.yellow;
    }
}
