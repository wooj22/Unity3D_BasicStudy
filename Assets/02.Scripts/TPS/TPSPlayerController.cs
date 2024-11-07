using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSPlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float spinSpeed = 90f;
    private Animation ani;

    private float h;
    private float v;
    private float mx;

    private void Start()
    {
        ani = GetComponent<Animation>();
    }

    private void Update()
    {
        Moving();
        Animation();
    }

    private void Moving()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        mx = Input.GetAxis("Mouse X");

        Vector3 moveDir = Vector3.forward * v + Vector3.right * h;
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * mx * spinSpeed * Time.deltaTime);
    }

    private void Animation()
    {
        if (v > 0.1f)
            ani.CrossFade("RunF", 0.3f);
        else if (v < -0.1f)
            ani.CrossFade("RunB", 0.3f);
        else if (h > 0.1f)
            ani.CrossFade("RunR", 0.3f);
        else if (h < -0.1f)
            ani.CrossFade("RunL", 0.3f);
        else
            ani.CrossFade("Idle", 0.3f);
    }
}
