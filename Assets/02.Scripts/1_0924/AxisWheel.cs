using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisWheel : MonoBehaviour
{
    void Update()
    {
        // GetAxis : Input 매니저에서 axisName으로 설정된 가상 축의 값을 반환
        // 마우스 휠 스크롤 -0.1(당김)~0.1(밀기)
        float mw = Input.GetAxis("Mouse ScrollWheel");
        if(mw != 0)
        {
            Debug.Log("Mouse ScrollWheel : " + mw);
        }
    }
}
