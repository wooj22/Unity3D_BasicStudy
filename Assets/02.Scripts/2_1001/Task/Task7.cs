using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ���� 7. ���� ������Ʈ �̵� + ȸ�� */
// ����Ű�� ������Ʈ �����¿� �̵� (���� ����)
// ���콺 �¿� �̵����� ������Ʈ ȸ��

public class Task7 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private Vector3 spinAxis;
    private float speed = 1f;
    private float spinSpeed = 180f;

    private float keyX;
    private float keyZ;
    private float mouseX;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveKey();
        SpinMouse();
    }

    // �̵�
    private void MoveKey()
    {
        keyX = Input.GetAxis("Horizontal");
        keyZ = Input.GetAxis("Vertical");
        moveDir = transform.TransformDirection(new Vector3(keyX, 0, keyZ)).normalized;

        rb.velocity = moveDir * speed;
    }

    // ȸ��
    private void SpinMouse()
    {
        mouseX = Input.GetAxis("Mouse X");
        spinAxis = transform.TransformDirection(new Vector3(mouseX, 0, 0)).normalized;

        rb.angularVelocity = spinAxis * spinSpeed;
    }
}
