using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ���콺 ������� ���� ������Ʈ ȸ�� */
public class MouseSpinPW : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 spinAxis;
    private float spinSpeed = 90f;
    private float mouseX;
    private float mouseY;
    private float scroll;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        SpinXYZ();
    }

    // ����6. ���콺 �����̵� X��ȸ��, ���콺 �¿��̵� Y�� ȸ��, �ٽ�ũ�� z�� ȸ��
    private void SpinXYZ()
    {
        mouseY = Input.GetAxis("Mouse X");
        mouseX = Input.GetAxis("Mouse Y");
        scroll = Input.GetAxis("Mouse ScrollWheel");

        spinAxis = new Vector3(mouseX, mouseY, scroll).normalized;
        rb.angularVelocity = spinAxis * spinSpeed;
    }
}
