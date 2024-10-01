using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity를 이용한 단순 점프 */
public class Jump : MonoBehaviour
{
    private float speed = 7f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector3.up * speed;
        }
    }
}
