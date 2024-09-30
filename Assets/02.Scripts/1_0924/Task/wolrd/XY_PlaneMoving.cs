using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XY_PlaneMoving : MonoBehaviour
{
    // GetAxis : Input �Ŵ������� axisName���� ������ ���� ���� ���� ��ȯ
    [SerializeField] float moveSpeed = 1f;

    void Update()
    {
        // ��ǲ�Ŵ���
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // ����������� XY ��� �̵�
        Vector3 move = new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
