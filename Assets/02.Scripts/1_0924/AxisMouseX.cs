using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisMouseX : MonoBehaviour
{
    void Update()
    {
        // GetAxis : Input �Ŵ������� axisName���� ������ ���� ���� ���� ��ȯ
        // ���콺 ���� �̵� (��������), ����(��)~���(��)
        float mx = Input.GetAxis("Mouse X");
        if (mx != 0)
        {
            Debug.Log("Mouse X GetAxis : " + mx);
        }

        // ���콺 ���� �̵� (��������), ����(��)~���(��)
        float my = Input.GetAxis("Mouse Y");
        if (mx != 0)
        {
            Debug.Log("Mouse Y GetAxis : " + my);
        }
    }
}
