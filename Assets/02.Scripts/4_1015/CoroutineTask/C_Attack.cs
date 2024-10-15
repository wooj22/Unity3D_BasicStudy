using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 공격 AI : 추적 범위 내에 플레이어가 있으면 공격함
public class C_Attack : MonoBehaviour
{
    [SerializeField] Transform playerTrans;
    [SerializeField] float limitDist = 5f;
    [SerializeField] GameObject bullet;
    private Coroutine aiCorutine;

    private void Start()
    {
        aiCorutine = StartCoroutine(AttackPlayer());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StopCoroutine(aiCorutine);
        }
    }

    IEnumerator AttackPlayer()
    {
        while (true)
        {
            // 플레이어까지 거리 계산
            float dist = (playerTrans.position - transform.position).magnitude;

            // 공격거리 이내라면 총알 발사
            if (dist < limitDist)
            {
                Vector3 shotDir = playerTrans.position - transform.position;
                Quaternion targetquat = Quaternion.LookRotation(shotDir);

                Instantiate(bullet, transform.position, targetquat);
            }
        }
    }
}
