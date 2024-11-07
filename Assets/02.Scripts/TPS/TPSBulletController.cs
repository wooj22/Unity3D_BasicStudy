using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSBulletController : MonoBehaviour
{
    public float damege = 20f;
    public float speed = 20f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
