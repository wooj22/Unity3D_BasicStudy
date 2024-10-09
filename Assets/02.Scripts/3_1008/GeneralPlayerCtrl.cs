using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� 6
public class GeneralPlayerCtrl : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    public float moveSpeed;
    public float rotationSpeed;

    private Vector3 moveDir;

    private float mouseX;
    private float keyAD;
    private float keyWS;

    private void Update()
    {
        Move();
        Rotation();
        Shot();
    }

    // �����¿� ����Ű�� XY ��� �����¿� �̵� (���� ����)
    void Move()
    {
        keyAD = Input.GetAxis("Horizontal");
        keyWS = Input.GetAxis("Vertical");

        moveDir = (new Vector3(keyAD, keyWS, 0) * moveSpeed * Time.deltaTime);
        transform.Translate(moveDir, Space.World);
    }

    // ���콺 ���� �̵����� Z�� ���� ȸ�� (���� ����)
    void Rotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, 0, mouseX * rotationSpeed * Time.deltaTime, Space.World);
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
