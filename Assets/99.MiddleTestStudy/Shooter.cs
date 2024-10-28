using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // player
    [SerializeField] GameObject bulletPre;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationsSpeed;
    [SerializeField] float jumpSpeed;

    private Vector3 moveDir;
    private Rigidbody rb;

    // axis
    private float horizontal;
    private float vertical;
    private float mouseX;
    private float mouseScroll;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetAxising();
        Moving();
        Shot();
    }

    private void GetAxising()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
    }

    private void Moving()
    {
        moveDir = (transform.right * horizontal + transform.forward * vertical).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }
        
        rb.angularVelocity = transform.up * mouseX * rotationsSpeed;

        transform.localScale += Vector3.one * mouseScroll;
    }

    private void Shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPre, this.transform.position, this.transform.rotation);
            Destroy(bullet, 3f);
        }
    }
}
