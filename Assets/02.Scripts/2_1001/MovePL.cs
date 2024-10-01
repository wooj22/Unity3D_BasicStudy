using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity ���� �̵�*/
// ������ݿ��� Local ��ǥ�� ����Ϸ��� transform.up

public class MovePL : MonoBehaviour
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

    // ���ñ��� ������ �̵�
    private void MoveForward()
    {
        rb.velocity = transform.forward * speed;
    }

    // ���ñ��� ������ �̵�
    private void MoveRight()
    {
        rb.velocity = transform.right * speed;
    }


    // ���ñ��� ���� �̵�
    private void MoveUp()
    {
        rb.velocity = transform.up * speed;
    }
}
