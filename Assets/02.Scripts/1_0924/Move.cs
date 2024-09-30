using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float xSpeedLocal = 2f;
    [SerializeField] float ySpeedLocal = 3f;
    [SerializeField] float zSpeedLocal = 1f;

    [SerializeField] float xSpeedWlord = -1f;
    [SerializeField] float ySpeedWlord = -2f;
    [SerializeField] float zSpeedWlord = -3f;

    void Update()
    {
        float xLenLocal = xSpeedLocal * Time.deltaTime;
        float yLenLocal = ySpeedLocal * Time.deltaTime;
        float zLenLocal = zSpeedLocal * Time.deltaTime;

        float xLenWlord = xSpeedWlord * Time.deltaTime;
        float yLenWlord = ySpeedWlord * Time.deltaTime;
        float zLenWlord = zSpeedWlord * Time.deltaTime;

        // z축으로 초당 nSpeed유닛 이동, (로컬좌표기준)
        // transform.Translate(xLenLocal, yLenLocal, zLenLocal, Space.Self);

        // z축으로 초당 nSpeed유닛 이동, (월드좌표기준)
        transform.Translate(xLenWlord, yLenWlord, zLenWlord, Space.World);
    }
}
