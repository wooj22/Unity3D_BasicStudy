using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* angularVelocity ���� ȸ�� */
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

    // X�� ���� ȸ��
    private void SpinX()
    {
        spinAxis = Vector3.right;
        rd.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }

    // Y�� ���� ȸ��
    private void SpinY()
    {
        spinAxis = Vector3.up;
        rd.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }

    // Z�� ���� ȸ��
    private void SpinZ()
    {
        spinAxis = Vector3.forward;
        rd.angularVelocity = spinAxis * speed * Mathf.Deg2Rad;
    }
}
