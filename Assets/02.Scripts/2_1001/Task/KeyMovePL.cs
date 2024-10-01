using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WASD ���ñ��� ���� ������Ʈ �̵� */
// transform.TransformDirection : ��������� ���� �������� ��ȯ
public class KeyMovePL : MonoBehaviour
{
    private Rigidbody rd;
    private Vector3 moveDir;
    private float speed = 1f;
    private float axisX;
    private float axisY;
    private float axisZ;

    private void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //MoveXY();
        //MoveXZ();
    }

    // ����1. ���ñ��� XY Ű �̵� 
    private void MoveXY()
    {
        axisX = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");

        moveDir = transform.TransformDirection(new Vector3(axisX, axisY, 0)).normalized;
        rd.velocity = moveDir * speed;
    }

    // ����2. ���ñ��� XZ Ű �̵�
    private void MoveXZ()
    {
        axisX = Input.GetAxis("Horizontal");
        axisZ = Input.GetAxis("Vertical");

        moveDir = transform.TransformDirection(new Vector3(axisX, 0, axisZ)).normalized;
        rd.velocity = moveDir * speed;
    }
}
