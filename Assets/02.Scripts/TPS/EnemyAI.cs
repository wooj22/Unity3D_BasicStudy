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

    EnemyFire enemyFire;

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
        enemyFire = GetComponent<EnemyFire>();

        // 애니메이션 시작 지점, 이동 속도
        animator.SetFloat("Offset", Random.Range(0.0f, 1.0f));
        animator.SetFloat("WalkSpeed", Random.Range(1.0f, 1.2f));
    }

    private void Update()
    {
        animator.SetFloat("Speed", moveAgent.GetSpeed());   // 현재 속도 전달
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
                    enemyFire.isFire = false;
                    moveAgent.SetPatrolling(true);
                    animator.SetBool("isMove", true);
                    break;
                case State.TRACE:  // 추적
                    enemyFire.isFire = false;
                    moveAgent.SetTraceTarget(playerTr.position);
                    animator.SetBool("isMove", true);
                    break;
                case State.ATTACK:  // 공격
                    enemyFire.isFire = true;
                    moveAgent.Stop();
                    animator.SetBool("isMove", false);
                    break;
                case State.DIE:  // 사망
                    isDie = true;
                    enemyFire.isFire = false;
                    moveAgent.Stop();
                    animator.SetTrigger("Die");
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }
        }       
    }

    /// 플레이어 사망
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
