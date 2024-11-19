using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamege : MonoBehaviour
{
    public GameObject bloodEffect;
    private float hp = 100f;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BULLET"))
        {
            ShowBloodEffect(collision);
            hp -= collision.gameObject.GetComponent<TPSBulletController>().damege;
            Debug.Log("Enemy HP : " + hp);

            if (hp < 0.001f)
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
        }
    }

    void ShowBloodEffect(Collision coll)
    {

    } 
}
