using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 과제 7
public class PhysicsPlayerCtrl : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Rigidbody rb;
    public float moveSpeed;
    public float rotationSpeed;

    private Vector3 moveDir;
    private float mouseX;
    private float keyWS;
    private float keyAD;

    private void Update()
    {
        Move();
        Rotation();
        Shot();
    }

    // 상하좌우 방향키로 XZ 평면 전후좌우 이동 (월드 기준)
    void Move()
    {
        keyWS = Input.GetAxis("Vertical");
        keyAD = Input.GetAxis("Horizontal");

        moveDir = new Vector3(keyAD, 0, keyWS).normalized;
        rb.velocity = moveDir * moveSpeed;
    }

    // 마우스 수평 이동으로 Y축 기준 회전 (월드 기준)
    void Rotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        rb.angularVelocity = Vector3.up * mouseX * rotationSpeed;
    }

    // 스페이스바로 총알 발사
    // 총알은 플레이어 위치에서 플레이어 앞쪽으로 발사 (로컬 Z축)
    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        }
    }
}
