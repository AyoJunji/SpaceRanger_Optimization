using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float chaserSpawnTimer = 3f;
    private float shooterSpawnTimer = 5.5f;
    private float bomberSpawnTimer = 11f;

    public GameObject enemyChaser;
    public GameObject enemyShooter;
    public GameObject enemyBomber;



    private void Start()
    {
        StartSpawning();
    }

    //Start the enemy spawner for each enemy
    void StartSpawning()
    {
        StartCoroutine(SpawnChaser(chaserSpawnTimer));
        StartCoroutine(SpawnShooter(shooterSpawnTimer));
        StartCoroutine(SpawnBomber(bomberSpawnTimer));
    }

    //SPAWN CHASER
    public IEnumerator SpawnChaser(float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(enemyChaser, new Vector2(Random.Range(-8, 8), 6f), Quaternion.identity);
        StartCoroutine(SpawnChaser(chaserSpawnTimer));
    }

    //SPAWN SHOOTER
    public IEnumerator SpawnShooter(float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(enemyShooter, new Vector2(Random.Range(-8, 8), 6f), Quaternion.identity);
        StartCoroutine(SpawnShooter(shooterSpawnTimer));
    }

    //SPAWN BOMBER
    public IEnumerator SpawnBomber(float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(enemyBomber, new Vector2(Random.Range(-8, 8), 6f), Quaternion.identity);
        StartCoroutine(SpawnBomber(bomberSpawnTimer));
    }
}
