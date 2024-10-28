using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// ���� AI : ���� ���� ���� �÷��̾ ������ ������
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
        // �÷��̾���� �Ÿ� ���
        float dist = (player.position - transform.position).magnitude;

        // ���ݰŸ� �̳���� �Ѿ� �߻�
        if(dist < limitDist)
        {
            Vector3 shotDir = player.position - transform.position;
            Quaternion targetquat = Quaternion.LookRotation(shotDir);

            Instantiate(bullet, transform.position, targetquat);
        }
    }
}
