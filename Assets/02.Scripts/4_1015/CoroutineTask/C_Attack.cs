using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// ���� AI : ���� ���� ���� �÷��̾ ������ ������
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
            // �÷��̾���� �Ÿ� ���
            float dist = (playerTrans.position - transform.position).magnitude;

            // ���ݰŸ� �̳���� �Ѿ� �߻�
            if (dist < limitDist)
            {
                Vector3 shotDir = playerTrans.position - transform.position;
                Quaternion targetquat = Quaternion.LookRotation(shotDir);

                Instantiate(bullet, transform.position, targetquat);
            }
        }
    }
}
