using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerCtrl : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Rigidbody rb;
    public float moveSpeed = 5f;
    public float rotationSpeed = 7f;
    private float mouseX;
    private float keyVertical;
    private float keyHorizontal;

    private void Update()
    {
        Move();
        Rotation();
        Shot();
    }

    // 상하좌우 방향키로 XZ 평면 전후좌우 이동 (월드 기준)
    void Move()
    {
        keyVertical = Input.GetAxis("Vertical");
        keyHorizontal = Input.GetAxis("Horizontal");
    }

    // 마우스 수평 이동으로 Y축 기준 회전
    void Rotation()
    {
        mouseX = Input.GetAxis("Mouse X");
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
