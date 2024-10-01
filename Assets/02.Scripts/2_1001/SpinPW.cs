using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* angularVelocity 월드 회전 */
public class SpinPW : MonoBehaviour
{
    private Rigidbody rd;
    private float speed = 90f;
    private Vector3 spinAxis;

    private void Start()
    {
        rd = GetComponent<Rigidbody>();

        //SpinX();
        //SpinY();
        //SpinZ();
    }

    // X축 월드 회전
    private void SpinX()
    {
        spinAxis = Vector3.right;
        rd.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }

    // Y축 월드 회전
    private void SpinY()
    {
        spinAxis = Vector3.up;
        rd.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }

    // Z축 월드 회전
    private void SpinZ()
    {
        spinAxis = Vector3.forward;
        rd.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }
}
