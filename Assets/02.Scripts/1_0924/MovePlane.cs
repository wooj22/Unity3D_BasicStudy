using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    public float speed = -1f;        // �ʴ� �̵� �ӵ�
    Vector3 dir;                    // �̵�����

    void Update()
    {
        // XZ ��鿡�� �ʴ� speed���� �ӵ��� �̵�(���ñ���)
        /*
        dir = new Vector3(1, 0, 1);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.Self);
        */


        // YZ ��鿡�� �ʴ� speed���� �ӵ��� �̵�(���ñ���)
        /*
        dir = new Vector3(0, 1, 1);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.Self);
        */

        // XY ��鿡�� �ʴ� speed���� �ӵ��� �̵�(�������)
        /*
        dir = new Vector3(1, 1, 0);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.World);
        */

        // YZ ��鿡�� �ʴ� speed���� �ӵ��� �̵�(�������)
        /*
        dir = new Vector3(0, 1, 1);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.World);
        */


        // XZ ��鿡�� �ʴ� speed���� �ӵ��� �̵�(�������)
        /*
        dir = new Vector3(1, 0, 1);
        dir = dir.normalized * speed * Time.deltaTime;
        transform.Translate(dir, Space.World);
        */
    }
}
