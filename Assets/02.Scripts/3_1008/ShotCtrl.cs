using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCtrl : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }
    }
}
