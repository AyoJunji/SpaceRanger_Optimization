using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float chaserSpawnTimer = 3f;
    public float shooterSpawnTimer = 5f;
    public float bomberSpawnTimer = 7f;

    public GameObject enemyChaser;
    public GameObject enemyShooter;
    public GameObject enemyBomber;

    private void Awake()
    {
        SpawnChaser(chaserSpawnTimer);
        SpawnShooter(shooterSpawnTimer);
        SpawnBomber(bomberSpawnTimer);
    }

    private void Start()
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
