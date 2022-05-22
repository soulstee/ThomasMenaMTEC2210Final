using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    public GameObject enemy5Prefab;

    public TextMeshPro timerText;
    private Timer timer;


    public Transform[] enemySpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        InvokeRepeating("SpawnEnemy", 6, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timerIsRunning)
        {
            timerText.text = timer.GetTimeForDisplay();
        }
    }

    void SpawnEnemy()
    {   
        int index = Random.Range(0, enemySpawnPoints.Length);
        Vector3 spawnPos = enemySpawnPoints[index].position;


        GameObject enemy1 = Instantiate(enemy1Prefab, spawnPos, Quaternion.identity);
        enemy1.GetComponent<EnemyMovement>().speed = Random.Range(-1.0f, -6.0f);

        GameObject enemy2 = Instantiate(enemy2Prefab, spawnPos, Quaternion.identity);
        enemy2.GetComponent<EnemyMovement>().speed = Random.Range(-1.0f, -6.0f);

        GameObject enemy3 = Instantiate(enemy3Prefab, spawnPos, Quaternion.identity);
        enemy3.GetComponent<EnemyMovement>().speed = Random.Range(-1.0f, -6.0f);

        GameObject enemy4 = Instantiate(enemy4Prefab, spawnPos, Quaternion.identity);
        enemy4.GetComponent<EnemyMovement>().speed = Random.Range(-1.0f, -6.0f);

        GameObject enemy5 = Instantiate(enemy5Prefab, spawnPos, Quaternion.identity);
        enemy5.GetComponent<EnemyMovement>().speed = Random.Range(-1.0f, -6.0f);
    }
}
