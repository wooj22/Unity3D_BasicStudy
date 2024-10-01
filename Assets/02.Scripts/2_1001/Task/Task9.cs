using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ���� 9. ���� ������Ʈ �̵� + ȸ�� + ���� */
// ���� ����Ű�� ������Ʈ ���� �̵� (���� ����)
// �¿� ����Ű�� ������Ʈ ȸ�� (���� ����)
// �����̽��ٷ� ������Ʈ ����

// ���ñ������� �ϴ� 2���� ���
// moveDir = transform.TransformDirection(new Vector3(axisX, axisY, 0)).normalized;
// moveDir = (transform.right * axisX + transform.up * axisY).normalized;

public class Task9 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private Vector3 spinAxis;
    private float speed = 5f;
    private float rotationSpeed = 90f;
    private float jumpSpeed = 5f;  

    float keyVertical;
    float keyHorizontal;

    private Vector3 Vel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveKey();
        RotateKey();
        Jump();

        rb.velocity = Vel;
    }

    // �̵�(����)
    private void MoveKey()
    {
        keyVertical = Input.GetAxis("Vertical"); 
        moveDir = transform.TransformDirection(new Vector3(0,0,keyVertical)).normalized;

        Vel = moveDir * speed;
    }

    // ȸ��(����)
    private void RotateKey()
    {
        keyHorizontal = Input.GetAxis("Horizontal");
        spinAxis = new Vector3(0, keyHorizontal, 0).normalized;

        rb.angularVelocity = spinAxis * rotationSpeed * Mathf.Deg2Rad;
    }

    // ����
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vel.y = jumpSpeed;
        }
        else
        {
            Vel.y = rb.velocity.y;
        }
    }
}
