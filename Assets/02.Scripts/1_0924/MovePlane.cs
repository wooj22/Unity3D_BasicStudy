using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    public float speed = -1f;        // 초당 이동 속도
    Vector3 dir;                    // 이동방향

    void Update()
    {
        // XZ 평면에서 초당 speed유닛 속도로 이동(로컬기준)
        /*
        dir = new Vector3(1, 0, 1);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.Self);
        */


        // YZ 평면에서 초당 speed유닛 속도로 이동(로컬기준)
        /*
        dir = new Vector3(0, 1, 1);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.Self);
        */

        // XY 평면에서 초당 speed유닛 속도로 이동(월드기준)
        /*
        dir = new Vector3(1, 1, 0);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.World);
        */

        // YZ 평면에서 초당 speed유닛 속도로 이동(월드기준)
        /*
        dir = new Vector3(0, 1, 1);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.World);
        */


        // XZ 평면에서 초당 speed유닛 속도로 이동(월드기준)
        /*
        dir = new Vector3(1, 0, 1);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.World);
        */
    }
}
