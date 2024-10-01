using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  마우스 로컬기준 물리 오브젝트 회전 */
// transform.TransformDirection : 월드방향을 로컬 기준으로 변환
public class MouseSpinPL : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 spinAxis;
    private float spinSpeed = 90f;
    private float mouseX;
    private float mouseY;
    private float scroll;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        SpinXYZ();
    }

    // 과제5. 마우스 상하이동 X축회전, 마우스 좌우이동 Y축 회전, 휠스크롤 z축 회전
    private void SpinXYZ()
    {
        mouseY = Input.GetAxis("Mouse X");
        mouseX = Input.GetAxis("Mouse Y");
        scroll = Input.GetAxis("Mouse ScrollWheel");

        spinAxis = transform.TransformDirection(new Vector3(mouseX, mouseY, scroll)).normalized;
        rb.angularVelocity = spinAxis * spinSpeed;
    }
}
