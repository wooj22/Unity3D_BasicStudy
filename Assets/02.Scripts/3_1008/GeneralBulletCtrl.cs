using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBulletCtrl : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        float len = speed * Time.deltaTime;
        transform.Translate(0, len, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
