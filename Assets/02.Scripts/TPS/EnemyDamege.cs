using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamege : MonoBehaviour
{
    public GameObject bloodEffect;
    private float hp = 100f;
    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0f, 2.2f, 0f);

    Canvas uiCanvas;
    Image hpBarImage;

    private void Start()
    {
        SetHpBar();
    }

    void SetHpBar()
    {
        uiCanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        GameObject hpBar = hpBarPrefab = Instantiate(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];
        EnemyHPBar bar = hpBar.GetComponent<EnemyHPBar>();
        bar.targetTr = gameObject.transform;
        bar.offset = hpBarOffset;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어 공격 성공
        if (collision.gameObject.CompareTag("BULLET"))
        {
            ShowBloodEffect(collision);
            hp -= collision.gameObject.GetComponent<TPSBulletController>().damege;
            hpBarImage.fillAmount = hp / 100f;
            Debug.Log("Enemy HP : " + hp);

            if (hp < 0.001f)
            {
                GetComponent<EnemyAI>().state = EnemyAI.State.DIE;
                hpBarImage.GetComponentsInParent<Image>()[1].color = Color.clear;

                Destroy(gameObject, 5f);
                GameObject.Find("GameManager").GetComponent<GameManager>().AddKillCount();
            }   
        }
    }

    void ShowBloodEffect(Collision coll)
    {

    } 
}
