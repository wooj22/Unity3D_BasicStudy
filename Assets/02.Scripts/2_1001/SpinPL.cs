using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* angularVelocity 로컬 회전 */
// Unity의 물리 각도는 라디안단위를 기준으로 하므로 (* Mathf.Deg2Rad)를 통해 값을 변환
public class SpinPL : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 360f;
    private Vector3 spinAxis;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //SpinX();
        //SpinY();
        SpinZ();
    }

    // X축 로컬 회전
    private void SpinX()
    {
        spinAxis = transform.right;
        rb.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }

    private void SpinY()
    {
        spinAxis = transform.up;
        rb.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }

    private void SpinZ()
    {
        spinAxis = transform.forward;
        rb.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }

    // Y축 로컬 회전


    // Z축 로컬 회전
}
