using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 90f;   // �ʴ� ȸ�� �ӵ�

    void Update()
    {
        float deg = speed * Time.deltaTime;     // �����Ӵ� ȸ�� ����

        // Y�� �������� �ʴ� deg�� ȸ��, ���ñ���
        //transform.Rotate(0, deg, 0);

        // X�� �������� �ʴ� deg�� ȸ��, ���ñ���
        //transform.Rotate(deg, 0, 0);

        // Z�� �������� �ʴ� deg�� ȸ��, ���ñ���
        //transform.Rotate(0, 0, deg);


        // Y�� �������� �ʴ� deg�� ȸ��, �������
        //transform.Rotate(0, deg, 0, Space.World);

        // X�� �������� �ʴ� deg�� ȸ��, �������
        //transform.Rotate(deg, 0, 0, Space.World));

        // Z�� �������� �ʴ� deg�� ȸ��, �������
        //transform.Rotate(0, 0, deg, Space.World));
    }
}
