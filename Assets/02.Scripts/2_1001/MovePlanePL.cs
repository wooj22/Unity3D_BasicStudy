using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity 로컬 평면 이동 */
// 두 벡터를 더할땐 정규화를 위해 normalized시킨다.
// 물리기반에서 Local 좌표를 사용하려면 transform.up

public class MovePlanePL : MonoBehaviour
{
    private float speed = 1f;
    private Rigidbody rb;
    private Vector3 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MovePlaneXZ();
        //MovePlaneXY();
        //MovePlaneYZ();
    }

    // XZ 로컬 평면 이동
    private void MovePlaneXZ()
    {
        moveDir = (transform.right + transform.forward).normalized;
        rb.velocity = moveDir * speed;
    }

    // XY 로컬 평면 이동
    private void MovePlaneXY()
    {
        moveDir = (transform.right + transform.up).normalized;
        rb.velocity = moveDir * speed;
    }

    // YZ 로컬 평면 이동
    private void MovePlaneYZ()
    {
        moveDir = (transform.up + transform.forward).normalized;
        rb.velocity = moveDir * speed;
    }
}
