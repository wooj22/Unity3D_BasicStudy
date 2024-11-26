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

    EnemyFire enemyFire;

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
        enemyFire = GetComponent<EnemyFire>();

        // �ִϸ��̼� ���� ����, �̵� �ӵ�
        animator.SetFloat("Offset", Random.Range(0.0f, 1.0f));
        animator.SetFloat("WalkSpeed", Random.Range(1.0f, 1.2f));
    }

    private void Update()
    {
        animator.SetFloat("Speed", moveAgent.GetSpeed());   // ���� �ӵ� ����
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
                    enemyFire.isFire = false;
                    moveAgent.SetPatrolling(true);
                    animator.SetBool("isMove", true);
                    break;
                case State.TRACE:  // ����
                    enemyFire.isFire = false;
                    moveAgent.SetTraceTarget(playerTr.position);
                    animator.SetBool("isMove", true);
                    break;
                case State.ATTACK:  // ����
                    enemyFire.isFire = true;
                    moveAgent.Stop();
                    animator.SetBool("isMove", false);
                    break;
                case State.DIE:  // ���
                    isDie = true;
                    enemyFire.isFire = false;
                    moveAgent.Stop();
                    animator.SetTrigger("Die");
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }
        }       
    }

    /// �÷��̾� ���
    public void OnPlayerDie()
    {
        if(isDie == false)
        {
            moveAgent.Stop();
            enemyFire.isFire = false;

            StopAllCoroutines();
            animator.SetTrigger("PlayerDie");
        }
    }
}
