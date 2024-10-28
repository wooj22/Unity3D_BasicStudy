using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAxisss : MonoBehaviour
{
    /// GetAxis�� 5���� ��ǲ�����͸� ��ȯ�Ѵ�.
    /// Horizontal : [a],[d] -1.0 ~ 1.0
    /// Vertical : [w],[s] 1.0 ~ -1.0
    /// Mouse X : ���콺 �¿� (����)~(���)
    /// Mouse Y : ���콺 ���� (���)~(����)
    /// Mouse ScrollWheel : ���콺 �ٽ�ũ�� ���� 0.1 ~ -0.1
    private float horizon;
    private float vertical;
    private float mouseX;
    private float mouseY;
    private float mouseScroll;

    private void Start()
    {
        InvokeRepeating(nameof(ShowDebug), 0f, 2f);
    }

    private void Update()
    {
        horizon = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
    }

    void ShowDebug()
    {
        Debug.Log("Horizontal : " + horizon);
        Debug.Log("Vertical : " + vertical);
        Debug.Log("Mouse X : " + mouseX);
        Debug.Log("Mouse Y : " + mouseY);
        Debug.Log("Mouse ScrollWheel : " + mouseScroll);
    }
}
