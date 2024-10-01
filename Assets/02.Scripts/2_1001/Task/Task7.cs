using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 과제 7. 물리 오브젝트 이동 + 회전 */
// 방향키로 오브젝트 전후좌우 이동 (로컬 기준)
// 마우스 좌우 이동으로 오브젝트 회전

public class Task7 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private Vector3 spinAxis;
    private float speed = 1f;
    private float spinSpeed = 180f;

    private float keyX;
    private float keyZ;
    private float mouseX;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveKey();
        SpinMouse();
    }

    // 이동
    private void MoveKey()
    {
        keyX = Input.GetAxis("Horizontal");
        keyZ = Input.GetAxis("Vertical");
        moveDir = transform.TransformDirection(new Vector3(keyX, 0, keyZ)).normalized;

        rb.velocity = moveDir * speed;
    }

    // 회전
    private void SpinMouse()
    {
        mouseX = Input.GetAxis("Mouse X");
        spinAxis = transform.TransformDirection(new Vector3(mouseX, 0, 0)).normalized;

        rb.angularVelocity = spinAxis * spinSpeed;
    }
}
