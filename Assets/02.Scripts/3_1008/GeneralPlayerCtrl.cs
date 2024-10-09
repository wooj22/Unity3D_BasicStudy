using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 과제 6
public class GeneralPlayerCtrl : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    public float moveSpeed;
    public float rotationSpeed;

    private Vector3 moveDir;

    private float mouseX;
    private float keyAD;
    private float keyWS;

    private void Update()
    {
        Move();
        Rotation();
        Shot();
    }

    // 상하좌우 방향키로 XY 평면 상하좌우 이동 (월드 기준)
    void Move()
    {
        keyAD = Input.GetAxis("Horizontal");
        keyWS = Input.GetAxis("Vertical");

        moveDir = (new Vector3(keyAD, keyWS, 0) * moveSpeed * Time.deltaTime);
        transform.Translate(moveDir, Space.World);
    }

    // 마우스 수평 이동으로 Z축 기준 회전 (월드 기준)
    void Rotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, 0, mouseX * rotationSpeed * Time.deltaTime, Space.World);
    }

    // 스페이스바로 총알 발사
    // 총알은 플레이어 위치에서 플레이어 위쪽으로 발사 (로컬 Y축)
    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        }
    }
}
