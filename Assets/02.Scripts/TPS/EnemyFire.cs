using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public bool isFire = false;         //��� ����
    [SerializeField] public AudioClip fireSnd;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform firePos;

    AudioSource audioSrc;
    Animator animator;
    Transform playerTr;
    Transform enemyTr;
    ParticleSystem muzzleFlash;

    float fireTime = 0f;        // �߻� �ð�
    float fireRate = 0.5f;      // �߻� ����
    float damping = 10f;        // ȸ�� ���

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
        // �߻� ���� ����
        if (isFire)
        {
            if(Time.time > fireTime)
            {
                Fire();
                fireTime = Time.time + fireRate + Random.Range(0.0f, 0.5f);
            }

            // �÷��̾� �������� ȸ��
            Quaternion targetRot = Quaternion.LookRotation(
                playerTr.position - enemyTr.position);
            enemyTr.rotation = Quaternion.Slerp(
                enemyTr.rotation, targetRot, Time.deltaTime * damping);
        }
    }

    /// �Ѿ� �߻�
    void Fire()
    {
        animator.SetTrigger("Fire");
        audioSrc.PlayOneShot(fireSnd, 0.5f);
        muzzleFlash.Play();

        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
