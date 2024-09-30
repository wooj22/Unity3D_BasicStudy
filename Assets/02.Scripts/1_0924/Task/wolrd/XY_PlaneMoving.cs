using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XY_PlaneMoving : MonoBehaviour
{
    // GetAxis : Input 매니저에서 axisName으로 설정된 가상 축의 값을 반환
    [SerializeField] float moveSpeed = 1f;

    void Update()
    {
        // 인풋매니저
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 월드기준으로 XY 평면 이동
        Vector3 move = new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
