using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 500f;  // 회전 속도 설정

    void Update()
    {
        // 인풋매니저
        float mouseX = Input.GetAxis("Mouse X"); 
        float mouseY = Input.GetAxis("Mouse Y"); 
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        float degX = rotationSpeed * mouseX * Time.deltaTime; 
        float degY = rotationSpeed * mouseY * Time.deltaTime;  
        float degZ = rotationSpeed * scroll * Time.deltaTime;

        // X축 기준 회전 (마우스 상하 이동)
        transform.Rotate(degX, 0, 0);

        // Y축 기준 회전 (마우스 좌우 이동)
        transform.Rotate(0, degY, 0);

        // Z축 기준 회전 (마우스 휠 스크롤)
        transform.Rotate(0, 0, degZ);
    }
}
