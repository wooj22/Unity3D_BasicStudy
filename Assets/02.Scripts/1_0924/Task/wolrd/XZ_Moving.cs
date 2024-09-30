using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XZ_Moving : MonoBehaviour
{
    // GetAxis : Input 매니저에서 axisName으로 설정된 가상 축의 값을 반환
    [SerializeField] float moveSpeed = 1f;

    void Update()
    {
        // 인풋매니저
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 월드 기준으로 XZ 이동
        Vector3 move = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
