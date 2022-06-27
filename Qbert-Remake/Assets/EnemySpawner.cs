using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int[] directions = { -1, 1 };

    public GameObject enemy;

    bool keepSpawning = true;

    private void Update()
    {
        if (GameManager.Instance.spawning && keepSpawning)
        {
            StartCoroutine(CreateEnemies());
            keepSpawning = false;
        }
    }

    private IEnumerator CreateEnemies()
    {
        while (GameManager.Instance.spawning)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("Spawning...");
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        Debug.Log("Spawned an enemy!");
        GameObject newEnemy = Instantiate(enemy, new Vector2(0f, 0f), Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();

        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(0.5f);
            int rIndex = Random.Range(0, 2);
            enemyScript.xPos -= directions[rIndex];
            enemyScript.yPos -= 1.5f;
        }
        Destroy(newEnemy);
    }
}
