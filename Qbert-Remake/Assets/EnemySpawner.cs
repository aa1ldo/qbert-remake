using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int[] directions = { -1, 1 };
    float[] spawnPositions = { -1f, 1f };

    public GameObject enemy;

    bool keepSpawning = true;

    private void Start()
    {
        StartCoroutine(CreateEnemies());
    }

    private IEnumerator CreateEnemies()
    {
        while (keepSpawning)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("Spawning...");
            StartCoroutine(SpawnEnemy());
        }
    }


    // IEnumerator SpawnEnemy()
        // Choose a random spawn position
        // Instantiate the enemy at spawn position
        // Play spawn animation
        // yield return new WaitForSeconds(length of spawn animation);

    private IEnumerator SpawnEnemy()
    {
        Debug.Log("Spawned an enemy!");
        int rSpawn = Random.Range(0, 2);
        GameObject newEnemy = Instantiate(enemy, new Vector2(0f, -1.5f), Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();

        enemyScript.xPos = spawnPositions[rSpawn];
        enemyScript.yPos = -1.5f;

        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(0.5f);
            int rDirection = Random.Range(0, 2);
            enemyScript.xPos -= directions[rDirection];
            enemyScript.yPos -= 1.5f;
        }
        Destroy(newEnemy);
    }
}
