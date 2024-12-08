using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // map
    public Transform[] points;
    public GameObject enemy;

    // value
    public float createTIme = 2f;
    public int maxEnemy = 10;
    public bool isGameOver = false;

    // ui
    public Text killText;
    float killCount;
    public GameObject restartBtn;

    private void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        if (points.Length > 0)
            StartCoroutine(CreateEnemy());

        restartBtn.SetActive(false);
    }

    /// Enemy »ý¼º
    IEnumerator CreateEnemy()
    {
        while (!isGameOver)
        {
            int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount < maxEnemy)
            {
                yield return new WaitForSeconds(createTIme);
                int idx = Random.Range(0, points.Length);
                Instantiate(enemy, points[idx].position, points[idx].rotation);
            }
            else
                yield return null;
        }

        restartBtn.SetActive(true);
    }

    public void AddKillCount()
    {
        ++killCount;
        killText.text = "Kill Count " + killCount;
    }

    public void Restrart()
    {
        SceneManager.LoadScene("TPS");
        restartBtn.SetActive(true);
        isGameOver = false;
    }
}
