using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Enemy AI 상태
    public enum State
    {
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    // AI valuse
    public State state = State.PATROL;
    public float attackDist = 10f;  // 공격 사정거리
    public float traceDist = 20f;   // 추적 사정거리
    public bool isDie = false;

    // Transform
    public GameObject player;
    Transform playerTr;
    Transform enemyTr;

    WaitForSeconds ws;  // 코루틴 지연변수

    // Conponents
    public MoveAgent moveAgent;
    public Animator animator;

    private void Awake()
    {
        // 플레이어 위치 get
        if(player != null)
        {
            playerTr = player.transform;
        }

        enemyTr = GetComponent<Transform>();
        ws = new WaitForSeconds(0.3f);
        moveAgent = GetComponent<MoveAgent>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable() // 활성화 생명주기
    {
        StartCoroutine(CheackState());
        StartCoroutine(Action());
    }

    /// AI 상태 제어
    IEnumerator CheackState()
    {
        while (!isDie)
        {
            // AI 사망시 종료
            if (state == State.DIE)
                yield break;

            // AI 상태 제어
            playerTr = player.transform;
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            if (dist < attackDist) state = State.ATTACK;
            else if (dist < traceDist) state = State.TRACE;
            else state = State.PATROL;

            yield return ws;
        }
    }

    /// 행동 제어
    IEnumerator Action()
    {
        while (!isDie)
        {
            yield return ws;

            switch (state)
            {
                case State.PATROL:  // 순찰
                    moveAgent.SetPatrolling(true);
                    animator.SetBool("isMove", true);
                    break;
                case State.TRACE:  // 추적
                    moveAgent.SetTraceTarget(playerTr.position);
                    animator.SetBool("isMove", true);
                    break;
                case State.ATTACK:  // 공격
                    moveAgent.Stop();
                    animator.SetBool("isMove", false);
                    break;
                case State.DIE:  // 사망
                    moveAgent.Stop();
                    animator.SetBool("isMove", false);
                    break;
            }
        }       
    }
}
