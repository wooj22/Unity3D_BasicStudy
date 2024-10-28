using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 공격 AI : 추적 범위 내에 플레이어가 있으면 공격함
public class Attack : MonoBehaviour
{
    public Transform player;
    public float limitDist = 5f;
    public GameObject bullet;

    private void Start()
    {
        InvokeRepeating(nameof(AttackPlayer), 1, 2);
    }

    void AttackPlayer()
    {
        // 플레이어까지 거리 계산
        float dist = (player.position - transform.position).magnitude;

        // 공격거리 이내라면 총알 발사
        if(dist < limitDist)
        {
            Vector3 shotDir = player.position - transform.position;
            Quaternion targetquat = Quaternion.LookRotation(shotDir);

            Instantiate(bullet, transform.position, targetquat);
        }
    }
}
