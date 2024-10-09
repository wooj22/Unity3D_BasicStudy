using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� 7
public class PhysicsPlayerCtrl : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Rigidbody rb;
    public float moveSpeed;
    public float rotationSpeed;

    private Vector3 moveDir;
    private float mouseX;
    private float keyWS;
    private float keyAD;

    private void Update()
    {
        Move();
        Rotation();
        Shot();
    }

    // �����¿� ����Ű�� XZ ��� �����¿� �̵� (���� ����)
    void Move()
    {
        keyWS = Input.GetAxis("Vertical");
        keyAD = Input.GetAxis("Horizontal");

        moveDir = new Vector3(keyAD, 0, keyWS).normalized;
        rb.velocity = moveDir * moveSpeed;
    }

    // ���콺 ���� �̵����� Y�� ���� ȸ�� (���� ����)
    void Rotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        rb.angularVelocity = Vector3.up * mouseX * rotationSpeed;
    }

    // �����̽��ٷ� �Ѿ� �߻�
    // �Ѿ��� �÷��̾� ��ġ���� �÷��̾� �������� �߻� (���� Z��)
    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        }
    }
}
