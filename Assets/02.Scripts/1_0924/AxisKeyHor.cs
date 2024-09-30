using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisKeyHor : MonoBehaviour
{
    void Update()
    {
        // GetAxis : Input �Ŵ������� axisName���� ������ ���� ���� ���� ��ȯ
        // ���� ���� Ű[A],[D] �Է½� GetAxis ��ȯ�� ���, -1.0(��) ~ 1.0(��)
        float hor = Input.GetAxis("Horizontal");
        if (hor != 0)
        {
            Debug.Log("Key Horizontal GetAxis : " + hor);
        }

        // ���� ���� Ű[W],[S] �Է½� GetAxis ��ȯ�� ���, -1.0(��) ~ 1.0(��)
        float ver = Input.GetAxis("Vertical");
        if (ver != 0)
        {
            Debug.Log("Key Vertical GetAxis : " + ver);
        }
    }
}
