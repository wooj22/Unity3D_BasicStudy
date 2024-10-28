using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl_1028 : MonoBehaviour
{
    // Conponent
    Rigidbody rb;

    // Speed
    private float moveSpeed = 5f;
    private float rotationSpeed = 90f;
    private float jumpSpeed = 5f;

    // Vector
    Vector3 moveDir;
    Vector3 vel;

    // GetAxis
    private float horizon;
    private float vertical;
    private float mouseX;
    private float mouseY;
    private float mouseScroll;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        //ObjectContrl();
        //ObjectContrlP();
        PysicsPlayer();
    }

    private void GetInput()
    {
        horizon = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
    }

    /// 오브젝트 일반 이동, 회전, 크기조절
    public void ObjectContrl()
    {
        // 일반제어에서 로컬,월드 좌표는 transfomr의 Self, World를 사용하여 전환
        // 로컬
        //moveDir = new Vector3(horizon, 0, vertical).normalized * moveSpeed * Time.deltaTime;
        //this.transform.Translate(moveDir, Space.Self);
        //this.transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0, Space.Self);
        //this.transform.localScale += Vector3.one * mouseScroll;

        // 월드
        //moveDir = new Vector3(horizon, 0, vertical).normalized * moveSpeed * Time.deltaTime;
        //this.transform.Translate(moveDir, Space.World);
        //this.transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0, Space.World);
        //this.transform.localScale += Vector3.one * mouseScroll;
    }


    /// 오브젝트 물리 이동, 회전
    public void ObjectContrlP()
    {
        // 물레제어에서 로컬, 월드 좌표는 transfrom.ㅇㅇ/ Vector.ㅇㅇ 을 통해 셋팅
        // 또는 'transform.TransformDirection'으로 월드방향을 로컬 기준으로 변환한다.
        // 로컬
        //vel = transform.forward*vertical + transform.right*horizon;
        //rb.velocity = vel.normalized * moveSpeed;
        //rb.angularVelocity = mouseScroll * transform.up * rotationSpeed;

        // 월드
        //vel = new Vector3(horizon, 0, vertical).normalized;
        //rb.velocity = vel * moveSpeed;
        //rb.angularVelocity = Vector3.up * mouseScroll * rotationSpeed;
    }

    // 물리 플레이어 컨드롤
    public void PysicsPlayer()
    {
        // 로컬 이동
        //vel = transform.TransformDirection(new Vector3(horizon, 0, vertical).normalized) * moveSpeed;
        vel = (transform.forward * vertical + transform.right * horizon) * moveSpeed;
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);

        // 로컬 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }

        // 월드 회전
        rb.angularVelocity = Vector3.up * mouseScroll * rotationSpeed;
    }
}
