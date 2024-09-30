using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XZ_Moving : MonoBehaviour
{
    // GetAxis : Input �Ŵ������� axisName���� ������ ���� ���� ���� ��ȯ
    [SerializeField] float moveSpeed = 1f;

    void Update()
    {
        // ��ǲ�Ŵ���
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // ���� �������� XZ �̵�
        Vector3 move = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
