using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity ���� �̵� */
// ������ݿ��� World ��ǥ�� ����Ϸ��� Vector.up

public class MovePW : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //MoveForward();
        //MoveRight();
        //MoveUp();
    }

    // ������� ������ �̵�
    private void MoveForward()
    {
        rb.velocity = Vector3.forward * speed;
    }

    // ������� ������ �̵�
    private void MoveRight()
    {
        rb.velocity = Vector3.right * speed;

    }

    // ������� ���� �̵�
    private void MoveUp()
    {
        rb.velocity = Vector3.up * speed;
    }
}
