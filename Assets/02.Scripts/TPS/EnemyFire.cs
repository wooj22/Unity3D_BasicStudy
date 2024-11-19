using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public bool isFire = false;         //사격 여부
    [SerializeField] public AudioClip fireSnd;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform firePos;

    AudioSource audioSrc;
    Animator animator;
    Transform playerTr;
    Transform enemyTr;
    ParticleSystem muzzleFlash;

    float fireTime = 0f;        // 발사 시간
    float fireRate = 0.5f;      // 발사 간격
    float damping = 10f;        // 회전 계수

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTr = player?.transform;
        enemyTr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        // 발사 간격 조절
        if (isFire)
        {
            if(Time.time > fireTime)
            {
                Fire();
                fireTime = Time.time + fireRate + Random.Range(0.0f, 0.5f);
            }

            // 플레이어 방향으로 회전
            Quaternion targetRot = Quaternion.LookRotation(
                playerTr.position - enemyTr.position);
            enemyTr.rotation = Quaternion.Slerp(
                enemyTr.rotation, targetRot, Time.deltaTime * damping);
        }
    }

    /// 총알 발사
    void Fire()
    {
        animator.SetTrigger("Fire");
        audioSrc.PlayOneShot(fireSnd, 0.5f);
        muzzleFlash.Play();

        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
