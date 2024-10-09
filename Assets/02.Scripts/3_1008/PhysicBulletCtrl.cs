using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBulletCtrl : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
