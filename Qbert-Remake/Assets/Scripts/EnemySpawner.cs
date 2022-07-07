using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int[] directions = { -1, 1 };
    float[] spawnPositions = { -1f, 1f };

    public GameObject enemy;

    Animator anim;

    public float minSpawnTime;
    public float maxSpawnTime;
    float spawnTime;

    public float animLength;
    public float waitLength;
    public float moveDuration;

    bool keepSpawning = true;

    private void Start()
    {
        StartCoroutine(CreateEnemies());
    }

    private IEnumerator CreateEnemies()
    {
        while (keepSpawning)
        {
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            Debug.Log("Spawning...");
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        int rSpawn = Random.Range(0, 2);
        GameObject newEnemy = Instantiate(enemy, new Vector2(spawnPositions[rSpawn], -1.5f), Quaternion.identity);
        anim = newEnemy.GetComponentInChildren<Animator>();
        anim.SetTrigger("Spawn");
        yield return new WaitForSeconds(animLength);

        for (int i = 0; i < 6; i++)
        {
            int rDirection = Random.Range(0, 2);
            StartCoroutine(MoveEnemy(newEnemy, new Vector2(newEnemy.transform.position.x - directions[rDirection], newEnemy.transform.position.y - 1.5f)));
            yield return new WaitForSeconds(waitLength);
        }
        Destroy(newEnemy);
    }

    private IEnumerator MoveEnemy(GameObject enemy, Vector2 targetPosition)
    {
        float time = 0f;

        while (time < moveDuration)
        {
            enemy.transform.position = Vector2.Lerp(enemy.transform.position, targetPosition, time / moveDuration);
            time += Time.deltaTime;
            yield return null;
        }
        enemy.transform.position = targetPosition;
    }

    // IEnumerator SpawnEnemy()
        // Choose a random spawn position
        // Instantiate the enemy at spawn position
        // Play spawn animation
        // yield return new WaitForSeconds(length of spawn animation);
        // Loop 6 times:
            // yield return new WaitForSeconds(length of movement);
            // Call the Movement coroutine
        // Destroy Enemy


    /*
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
    */
}
