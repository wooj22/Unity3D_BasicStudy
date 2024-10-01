using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity ���� ��� �̵� */
// �� ���͸� ���Ҷ� ����ȭ�� ���� normalized��Ų��.
// ������ݿ��� World ��ǥ�� ����Ϸ��� Vector.up

public class MovePlanePW : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private float speed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //MovePlaneXZ();
        //MovePlaneXY();
        //MovePlaneYZ();
    }

    // XZ ���� ��� �̵�
    private void MovePlaneXZ()
    {
        moveDir = (Vector3.right + Vector3.forward).normalized;
        rb.velocity = moveDir * speed;
    }


    // XY ���� ��� �̵�
    private void MovePlaneXY()
    {
        moveDir = (Vector3.right + Vector3.up).normalized;
        rb.velocity = moveDir * speed;
    }


    // YZ ���� ��� �̵�
    private void MovePlaneYZ()
    {
        moveDir = (Vector3.up + Vector3.forward).normalized;
        rb.velocity = moveDir * speed;
    }
}
