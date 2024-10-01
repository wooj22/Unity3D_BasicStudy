using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity ���� ��� �̵� */
// �� ���͸� ���Ҷ� ����ȭ�� ���� normalized��Ų��.
// ������ݿ��� Local ��ǥ�� ����Ϸ��� transform.up

public class MovePlanePL : MonoBehaviour
{
    private float speed = 1f;
    private Rigidbody rb;
    private Vector3 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MovePlaneXZ();
        //MovePlaneXY();
        //MovePlaneYZ();
    }

    // XZ ���� ��� �̵�
    private void MovePlaneXZ()
    {
        moveDir = (transform.right + transform.forward).normalized;
        rb.velocity = moveDir * speed;
    }

    // XY ���� ��� �̵�
    private void MovePlaneXY()
    {
        moveDir = (transform.right + transform.up).normalized;
        rb.velocity = moveDir * speed;
    }

    // YZ ���� ��� �̵�
    private void MovePlaneYZ()
    {
        moveDir = (transform.up + transform.forward).normalized;
        rb.velocity = moveDir * speed;
    }
}
