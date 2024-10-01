using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WASD 로컬기준 물리 오브젝트 이동 */
// transform.TransformDirection : 월드방향을 로컬 기준으로 변환
public class KeyMovePL : MonoBehaviour
{
    private Rigidbody rd;
    private Vector3 moveDir;
    private float speed = 1f;
    private float axisX;
    private float axisY;
    private float axisZ;

    private void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //MoveXY();
        //MoveXZ();
    }

    // 과제1. 로컬기준 XY 키 이동 
    private void MoveXY()
    {
        axisX = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");

        moveDir = transform.TransformDirection(new Vector3(axisX, axisY, 0)).normalized;
        rd.velocity = moveDir * speed;
    }

    // 과제2. 로컬기준 XZ 키 이동
    private void MoveXZ()
    {
        axisX = Input.GetAxis("Horizontal");
        axisZ = Input.GetAxis("Vertical");

        moveDir = transform.TransformDirection(new Vector3(axisX, 0, axisZ)).normalized;
        rd.velocity = moveDir * speed;
    }
}
