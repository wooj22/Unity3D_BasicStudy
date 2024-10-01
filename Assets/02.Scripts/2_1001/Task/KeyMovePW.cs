using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WASD 월드기준 물리 오브젝트 이동 */
public class KeyMovePW : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 1f;
    private Vector3 moveDir;
    private float axisX;
    private float axisY;
    private float axisZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //MoveXZ();
        //MoveXY();
    }

    // 과제3. 월드기준 XZ 키 이동 
    private void MoveXZ()
    {
        axisX = Input.GetAxis("Horizontal");
        axisZ = Input.GetAxis("Vertical");

        moveDir = new Vector3(axisX, 0, axisZ).normalized;
        rb.velocity = moveDir * speed;
    }

    // 과제4. 월드기준 XY 키 이동 
    private void MoveXY()
    {
        axisX = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");

        moveDir = new Vector3(axisX, axisY, 0).normalized;
        rb.velocity = moveDir * speed;
    }
}
