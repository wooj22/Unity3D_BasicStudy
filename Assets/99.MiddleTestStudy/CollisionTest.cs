using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // ÃÑ¾Ë Å×½ºÆ®
        rb.velocity = transform.forward * 5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Å¥ºê¿Í ´êÀ½");
        }
        else
        {
            Destroy(this.gameObject); // ÃÑ¾Ë Å×½ºÆ®
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Å¥ºê¿Í ´ê°íÀÖÀ½");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Å¥ºê¿Í ¶³¾îÁü");
        }
    }
}
