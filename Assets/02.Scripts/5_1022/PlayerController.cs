using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("PlayerData")]
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float rotationSpeed = 100f;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public Transform bulletParent;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
        Jump();
        Shoot();
    }

    // 상하좌우키 XZ평면 로컬기준 물리이동
    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(moveHorizontal, 0, moveVertical));
        Vector3 moveVelocity = moveDirection * moveSpeed;

        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }

    // 마우스 이동 y축 로컬기준 일반 회전
    void Rotate()
    {
        float rotationInput = Input.GetAxis("Mouse X");
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0, Space.Self);
    }

    // 점프
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // 좌클릭 총알 발사
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation, bulletParent);
        }
    }

    // 평지 인식
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("바닥과 닿음");
        }
    }
}
