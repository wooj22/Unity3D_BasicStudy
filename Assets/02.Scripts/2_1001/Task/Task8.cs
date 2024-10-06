using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 과제 8. 물리 오브젝트 이동 + 점프 */
// 방향키로 오브젝트 전후좌우 이동 (월드 기준)
// 스페이스바로 오브젝트 점프

public class Task8 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private float speed = 5f;
    private float jumpSpeed = 7f;

    private float keyX;
    private float keyZ;
    private Vector3 Vel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveKey();
        Jump();

        rb.velocity = Vel;
    }

    // 이동
    private void MoveKey()
    {
        keyX = Input.GetAxis("Horizontal");
        keyZ = Input.GetAxis("Vertical");
        moveDir = new Vector3(keyX, 0, keyZ).normalized;

        Vel.x = keyX * speed;
        Vel.z = keyZ * speed;
        //Vel = moveDir * speed;
    }

    // 점프
    private void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            Vel.y = jumpSpeed;
        }
        else
        {
            Vel.y = rb.velocity.y;
        }
    }
}
