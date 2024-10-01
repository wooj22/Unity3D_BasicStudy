using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity 월드 이동 */
// 물리기반에서 World 좌표를 사용하려면 Vector.up

public class MovePW : MonoBehaviour
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

    // 월드기준 전방향 이동
    private void MoveForward()
    {
        rb.velocity = Vector3.forward * speed;
    }

    // 월드기준 오른쪽 이동
    private void MoveRight()
    {
        rb.velocity = Vector3.right * speed;

    }

    // 월드기준 위쪽 이동
    private void MoveUp()
    {
        rb.velocity = Vector3.up * speed;
    }
}
