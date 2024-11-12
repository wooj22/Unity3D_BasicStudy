using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Enemy AI ����
    public enum State
    {
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    // AI valuse
    public State state = State.PATROL;
    public float attackDist = 10f;  // ���� �����Ÿ�
    public float traceDist = 20f;   // ���� �����Ÿ�
    public bool isDie = false;

    // Transform
    public GameObject player;
    Transform playerTr;
    Transform enemyTr;

    WaitForSeconds ws;  // �ڷ�ƾ ��������

    // Conponents
    public MoveAgent moveAgent;
    public Animator animator;

    private void Awake()
    {
        // �÷��̾� ��ġ get
        if(player != null)
        {
            playerTr = player.transform;
        }

        enemyTr = GetComponent<Transform>();
        ws = new WaitForSeconds(0.3f);
        moveAgent = GetComponent<MoveAgent>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable() // Ȱ��ȭ �����ֱ�
    {
        StartCoroutine(CheackState());
        StartCoroutine(Action());
    }

    /// AI ���� ����
    IEnumerator CheackState()
    {
        while (!isDie)
        {
            // AI ����� ����
            if (state == State.DIE)
                yield break;

            // AI ���� ����
            playerTr = player.transform;
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            if (dist < attackDist) state = State.ATTACK;
            else if (dist < traceDist) state = State.TRACE;
            else state = State.PATROL;

            yield return ws;
        }
    }

    /// �ൿ ����
    IEnumerator Action()
    {
        while (!isDie)
        {
            yield return ws;

            switch (state)
            {
                case State.PATROL:  // ����
                    moveAgent.SetPatrolling(true);
                    animator.SetBool("isMove", true);
                    break;
                case State.TRACE:  // ����
                    moveAgent.SetTraceTarget(playerTr.position);
                    animator.SetBool("isMove", true);
                    break;
                case State.ATTACK:  // ����
                    moveAgent.Stop();
                    animator.SetBool("isMove", false);
                    break;
                case State.DIE:  // ���
                    moveAgent.Stop();
                    animator.SetBool("isMove", false);
                    break;
            }
        }       
    }
}
