using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* velocity 월드 평면 이동 */
// 두 벡터를 더할땐 정규화를 위해 normalized시킨다.
// 물리기반에서 World 좌표를 사용하려면 Vector.up

public class MovePlanePW : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;
    private float speed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //MovePlaneXZ();
        //MovePlaneXY();
        //MovePlaneYZ();
    }

    // XZ 월드 평면 이동
    private void MovePlaneXZ()
    {
        moveDir = (Vector3.right + Vector3.forward).normalized;
        rb.velocity = moveDir * speed;
    }


    // XY 월드 평면 이동
    private void MovePlaneXY()
    {
        moveDir = (Vector3.right + Vector3.up).normalized;
        rb.velocity = moveDir * speed;
    }


    // YZ 월드 평면 이동
    private void MovePlaneYZ()
    {
        moveDir = (Vector3.up + Vector3.forward).normalized;
        rb.velocity = moveDir * speed;
    }
}
