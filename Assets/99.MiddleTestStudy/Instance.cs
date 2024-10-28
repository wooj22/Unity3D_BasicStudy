using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    // 스페이스바를 누르면 랜덤한 위치와 방향으로 생성, 1초뒤 자동 제거
    [SerializeField] GameObject cubePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new Vector3(Random.Range(-3f, 3f),
                Random.Range(-3f, 3f),
                Random.Range(-3f, 3f));
            Vector3 rotate = new Vector3(Random.Range(-360f, 360f),
                Random.Range(-360f, 360f),
                Random.Range(-3f, 3f));
            GameObject cube = Instantiate(cubePrefab, pos, Quaternion.Euler(rotate));
            Destroy(cube.gameObject, 1f);
        }
    }
}
