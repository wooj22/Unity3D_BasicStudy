using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisKeyHor : MonoBehaviour
{
    void Update()
    {
        // GetAxis : Input 매니저에서 axisName으로 설정된 가상 축의 값을 반환
        // 수평 방향 키[A],[D] 입력시 GetAxis 반환값 출력, -1.0(좌) ~ 1.0(우)
        float hor = Input.GetAxis("Horizontal");
        if (hor != 0)
        {
            Debug.Log("Key Horizontal GetAxis : " + hor);
        }

        // 수직 방향 키[W],[S] 입력시 GetAxis 반환값 출력, -1.0(하) ~ 1.0(상)
        float ver = Input.GetAxis("Vertical");
        if (ver != 0)
        {
            Debug.Log("Key Vertical GetAxis : " + ver);
        }
    }
}
