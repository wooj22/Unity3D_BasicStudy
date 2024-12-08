using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    private void Start()
    {
       // Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.CompareTag("BULLET"))
        {
            ShowEffect(coll);
            Destroy(coll.gameObject);
        }
    }

    void ShowEffect(Collision coll)
    {
        // 충돌지점
        ContactPoint contact = coll.contacts[0];

        // 법선 벡터가 이루는 회전 각도
        Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal);

        GameObject spark = Instantiate(sparkEffect, contact.point - (contact.normal * 0.05f), rot);
        spark.transform.SetParent(this.transform);
    }
}
