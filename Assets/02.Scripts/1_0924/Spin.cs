using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 90f;   // 초당 회전 속도

    void Update()
    {
        float deg = speed * Time.deltaTime;     // 프레임당 회전 각도

        // Y축 기준으로 초당 deg도 회전, 로컬기준
        //transform.Rotate(0, deg, 0);

        // X축 기준으로 초당 deg도 회전, 로컬기준
        //transform.Rotate(deg, 0, 0);

        // Z축 기준으로 초당 deg도 회전, 로컬기준
        //transform.Rotate(0, 0, deg);


        // Y축 기준으로 초당 deg도 회전, 월드기준
        //transform.Rotate(0, deg, 0, Space.World);

        // X축 기준으로 초당 deg도 회전, 월드기준
        //transform.Rotate(deg, 0, 0, Space.World));

        // Z축 기준으로 초당 deg도 회전, 월드기준
        //transform.Rotate(0, 0, deg, Space.World));
    }
}
