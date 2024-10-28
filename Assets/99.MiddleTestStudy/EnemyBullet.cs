using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(0,0,5f * Time.deltaTime, Space.Self); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 맞춤");
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
