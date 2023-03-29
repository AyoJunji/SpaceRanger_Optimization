using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float chaserSpawnTimer = 3f;
    public float shooterSpawnTimer = 5f;
    public float bomberSpawnTimer = 7f;

    public GameObject enemyChaser;
    public GameObject enemyShooter;
    public GameObject enemyBomber;

    private void Start()
    {
        STARTSPAWNING();
    }

    void STARTSPAWNING()
    {
        SpawnChaser(chaserSpawnTimer);
        SpawnShooter(shooterSpawnTimer);
        SpawnBomber(bomberSpawnTimer);
    }

    IEnumerator SpawnChaser(float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(enemyChaser, new Vector2(Random.Range(-8, 8), 10f), Quaternion.identity);
        SpawnChaser(chaserSpawnTimer);
    }

    IEnumerator SpawnShooter(float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(enemyShooter, new Vector2(Random.Range(-8, 8), 10f), Quaternion.identity);
        SpawnChaser(shooterSpawnTimer);
    }

    IEnumerator SpawnBomber(float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(enemyBomber, new Vector2(Random.Range(-8, 8), 10f), Quaternion.identity);
        SpawnChaser(bomberSpawnTimer);
    }
}
