using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisMouseX : MonoBehaviour
{
    void Update()
    {
        // GetAxis : Input 매니저에서 axisName으로 설정된 가상 축의 값을 반환
        // 마우스 수평 이동 (공백주의), 음수(좌)~양수(우)
        float mx = Input.GetAxis("Mouse X");
        if (mx != 0)
        {
            Debug.Log("Mouse X GetAxis : " + mx);
        }

        // 마우스 수직 이동 (공백주의), 음수(좌)~양수(우)
        float my = Input.GetAxis("Mouse Y");
        if (mx != 0)
        {
            Debug.Log("Mouse Y GetAxis : " + my);
        }
    }
}
