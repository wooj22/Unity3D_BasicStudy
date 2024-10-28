using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl_1028 : MonoBehaviour
{
    // Conponent
    Rigidbody rb;

    // Speed
    private float moveSpeed = 5f;
    private float rotationSpeed = 90f;
    private float jumpSpeed = 5f;

    // Vector
    Vector3 moveDir;
    Vector3 vel;

    // GetAxis
    private float horizon;
    private float vertical;
    private float mouseX;
    private float mouseY;
    private float mouseScroll;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        //ObjectContrl();
        //ObjectContrlP();
        PysicsPlayer();
    }

    private void GetInput()
    {
        horizon = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
    }

    /// ������Ʈ �Ϲ� �̵�, ȸ��, ũ������
    public void ObjectContrl()
    {
        // �Ϲ������ ����,���� ��ǥ�� transfomr�� Self, World�� ����Ͽ� ��ȯ
        // ����
        //moveDir = new Vector3(horizon, 0, vertical).normalized * moveSpeed * Time.deltaTime;
        //this.transform.Translate(moveDir, Space.Self);
        //this.transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0, Space.Self);
        //this.transform.localScale += Vector3.one * mouseScroll;

        // ����
        //moveDir = new Vector3(horizon, 0, vertical).normalized * moveSpeed * Time.deltaTime;
        //this.transform.Translate(moveDir, Space.World);
        //this.transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0, Space.World);
        //this.transform.localScale += Vector3.one * mouseScroll;
    }


    /// ������Ʈ ���� �̵�, ȸ��
    public void ObjectContrlP()
    {
        // ��������� ����, ���� ��ǥ�� transfrom.����/ Vector.���� �� ���� ����
        // �Ǵ� 'transform.TransformDirection'���� ��������� ���� �������� ��ȯ�Ѵ�.
        // ����
        //vel = transform.forward*vertical + transform.right*horizon;
        //rb.velocity = vel.normalized * moveSpeed;
        //rb.angularVelocity = mouseScroll * transform.up * rotationSpeed;

        // ����
        //vel = new Vector3(horizon, 0, vertical).normalized;
        //rb.velocity = vel * moveSpeed;
        //rb.angularVelocity = Vector3.up * mouseScroll * rotationSpeed;
    }

    // ���� �÷��̾� �����
    public void PysicsPlayer()
    {
        // ���� �̵�
        //vel = transform.TransformDirection(new Vector3(horizon, 0, vertical).normalized) * moveSpeed;
        vel = (transform.forward * vertical + transform.right * horizon) * moveSpeed;
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);

        // ���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }

        // ���� ȸ��
        rb.angularVelocity = Vector3.up * mouseScroll * rotationSpeed;
    }
}
