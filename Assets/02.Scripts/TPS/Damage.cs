using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public float curHP = 100;
    public Image bloodScreen;
    public Image hpBar;

    Color initColor = new Vector4(0f, 1f, 0f, 1f);
    Color curColor;

    private void Start()
    {
        hpBar.color = initColor;
        curColor = initColor;
    }

    /// 총알에 맞았을 때
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            curHP -= 5f;
            StartCoroutine(ShowBloodScreen());
            DisplayHpBar();
            Debug.Log("Player HP : " + curHP);
            if (curHP < 0.001f)
            {
                PlayerDie();
            }       
        }
    }

    /// 피격 이펙트
    IEnumerator ShowBloodScreen()
    {
        bloodScreen.color = new Color(
            1, 0, 0, Random.Range(0.5f, 1.0f));
        yield return new WaitForSeconds(0.1f);
        bloodScreen.color = Color.clear;
    }

    /// 체력바
    void DisplayHpBar()
    {
        float ratio = curHP / 100f;
        if (ratio > 0.5f)
            curColor.r = (1 - ratio) * 2f;
        else
            curColor.g = ratio * 2f;

        hpBar.color = curColor;
        hpBar.fillAmount = ratio;
    }

    /// 플레이어 사망
    void PlayerDie()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
            enemies[i].SendMessage("OnPlayerDie");

        GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;
    }
}
