using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* angularVelocity ���� ȸ�� */
// Unity�� ���� ������ ���ȴ����� �������� �ϹǷ� (* Mathf.Deg2Rad)�� ���� ���� ��ȯ
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

    // X�� ���� ȸ��
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

    // Y�� ���� ȸ��


    // Z�� ���� ȸ��
}
