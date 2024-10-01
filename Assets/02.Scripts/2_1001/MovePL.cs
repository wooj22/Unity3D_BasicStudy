using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity 로컬 이동*/
// 물리기반에서 Local 좌표를 사용하려면 transform.up

public class MovePL : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //MoveForward();
        //MoveRight();
        //MoveUp();
    }

    // 로컬기준 전방향 이동
    private void MoveForward()
    {
        rb.velocity = transform.forward * speed;
    }

    // 로컬기준 오른쪽 이동
    private void MoveRight()
    {
        rb.velocity = transform.right * speed;
    }


    // 로컬기준 위쪽 이동
    private void MoveUp()
    {
        rb.velocity = transform.up * speed;
    }
}
