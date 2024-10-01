using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 과제 9. 물리 오브젝트 이동 + 회전 + 점프 */
// 상하 방향키로 오브젝트 전후 이동 (로컬 기준)
// 좌우 방향키로 오브젝트 회전 (월드 기준)
// 스페이스바로 오브젝트 점프

// 로컬기준으로 하는 2가지 방법
// moveDir = transform.TransformDirection(new Vector3(axisX, axisY, 0)).normalized;
// moveDir = (transform.right * axisX + transform.up * axisY).normalized;

public class Task9 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private Vector3 spinAxis;
    private float speed = 5f;
    private float rotationSpeed = 90f;
    private float jumpSpeed = 5f;  

    float keyVertical;
    float keyHorizontal;

    private Vector3 Vel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveKey();
        RotateKey();
        Jump();

        rb.velocity = Vel;
    }

    // 이동(로컬)
    private void MoveKey()
    {
        keyVertical = Input.GetAxis("Vertical"); 
        moveDir = transform.TransformDirection(new Vector3(0,0,keyVertical)).normalized;

        Vel = moveDir * speed;
    }

    // 회전(월드)
    private void RotateKey()
    {
        keyHorizontal = Input.GetAxis("Horizontal");
        spinAxis = new Vector3(0, keyHorizontal, 0).normalized;

        rb.angularVelocity = spinAxis * rotationSpeed * Mathf.Deg2Rad;
    }

    // 점프
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vel.y = jumpSpeed;
        }
        else
        {
            Vel.y = rb.velocity.y;
        }
    }
}
