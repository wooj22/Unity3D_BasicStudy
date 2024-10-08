using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlayerCtrl : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float rotationSpeed = 7f;
    private float mouseX;
    private float keyVertical;
    private float keyHorizontal;

    private void Update()
    {
        Move();
        Rotation();
        Shot();
    }

    // �����¿� ����Ű�� XY ��� �����¿� �̵� (���� ����)
    void Move()
    {
        keyVertical = Input.GetAxis("Vertical");
        keyHorizontal = Input.GetAxis("Horizontal");
    }

    // ���콺 ���� �̵����� Z�� ���� ȸ��
    void Rotation()
    {
        mouseX = Input.GetAxis("Mouse X");
    }

    // �����̽��ٷ� �Ѿ� �߻�
    // �Ѿ��� �÷��̾� ��ġ���� �÷��̾� �������� �߻� (���� Y��)
    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        }
    }
}
