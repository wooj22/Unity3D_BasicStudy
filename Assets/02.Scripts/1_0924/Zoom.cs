using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float ratio = 0.5f;     // �ʴ� Ȯ�� ����

    void Update()
    {
        float len = ratio * Time.deltaTime;

        // �ʴ� len�� Ȯ��
        //transform.localScale += Vector3.one * len;

        // �ʴ� len�� ���
        transform.localScale -= Vector3.one * len;
    }
}
