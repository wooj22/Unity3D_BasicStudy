using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisWheel : MonoBehaviour
{
    void Update()
    {
        // GetAxis : Input �Ŵ������� axisName���� ������ ���� ���� ���� ��ȯ
        // ���콺 �� ��ũ�� -0.1(���)~0.1(�б�)
        float mw = Input.GetAxis("Mouse ScrollWheel");
        if(mw != 0)
        {
            Debug.Log("Mouse ScrollWheel : " + mw);
        }
    }
}
