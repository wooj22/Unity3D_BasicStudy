using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 500f;  // ȸ�� �ӵ� ����

    void Update()
    {
        // ��ǲ�Ŵ���
        float mouseX = Input.GetAxis("Mouse X"); 
        float mouseY = Input.GetAxis("Mouse Y"); 
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        float degX = rotationSpeed * mouseX * Time.deltaTime; 
        float degY = rotationSpeed * mouseY * Time.deltaTime;  
        float degZ = rotationSpeed * scroll * Time.deltaTime;

        // X�� ���� ȸ�� (���콺 ���� �̵�)
        transform.Rotate(degX, 0, 0);

        // Y�� ���� ȸ�� (���콺 �¿� �̵�)
        transform.Rotate(0, degY, 0);

        // Z�� ���� ȸ�� (���콺 �� ��ũ��)
        transform.Rotate(0, 0, degZ);
    }
}
