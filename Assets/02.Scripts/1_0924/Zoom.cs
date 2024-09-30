using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float ratio = 0.5f;     // 초당 확대 비율

    void Update()
    {
        float len = ratio * Time.deltaTime;

        // 초당 len배 확대
        //transform.localScale += Vector3.one * len;

        // 초당 len배 축소
        transform.localScale -= Vector3.one * len;
    }
}
