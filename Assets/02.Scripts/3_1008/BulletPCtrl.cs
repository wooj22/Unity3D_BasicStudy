using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPCtrl : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;

        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
