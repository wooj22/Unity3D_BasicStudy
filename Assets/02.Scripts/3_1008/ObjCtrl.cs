using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� 1. �����̽��ٷ� ������Ʈ �����ϱ�
public class ObjCtrl : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private GameObject obj;
    private Vector3 pos;
    private Vector3 rot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatObject();
        }
    }

    private void CreatObject()
    {
        pos = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
        rot = new Vector3(0, 0, Random.Range(0, 360));

        obj = Instantiate(prefab, pos, Quaternion.Euler(rot));
        Destroy(obj, 1f);
    }
}
