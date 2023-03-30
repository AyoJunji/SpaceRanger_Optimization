using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public Vector3 targetPos;
    private float maxHealth = 200f;
    private float currentHealth;
    public Boss_HP_Bar bossHP;

    private float speed = 100f;
    public Transform barrel, barrel2;
    private float cooldown = 8f;
    public Rigidbody2D bullet;

    void Start()
    {
        currentHealth = maxHealth;

        bossHP.UpdateHealthBar(maxHealth, currentHealth);
        StartCoroutine(ShootProjectile(cooldown));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != targetPos)
        {
            transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        bossHP.UpdateHealthBar(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

    IEnumerator ShootProjectile(float timer)
    {
        yield return new WaitForSeconds(timer);
        Shoot();
        StartCoroutine(ShootProjectile(cooldown));
    }
    private void Shoot()
    {
        for (int i = 0; i <= 5; i ++)
        {
            var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            var spawnedBullet2 = Instantiate(bullet, barrel2.position, barrel2.rotation);

            switch(i)
            {
                case 0:
                    spawnedBullet.AddForce(barrel.up * speed + new Vector3(-90f, 0f, 0f));
                    spawnedBullet2.AddForce(barrel2.up * speed + new Vector3(-90f, 0f, 0f));
                    break;
                case 1:
                    spawnedBullet.AddForce(barrel.up * speed + new Vector3(-45f, 0f, 0f));
                    spawnedBullet2.AddForce(barrel2.up * speed + new Vector3(-45f, 0f, 0f));
                    break;
                case 2:
                    spawnedBullet.AddForce(barrel.up * speed + new Vector3(-15f, 0f, 0f));
                    spawnedBullet2.AddForce(barrel2.up * speed + new Vector3(-15f, 0f, 0f));
                    break;
                case 3:
                    spawnedBullet.AddForce(barrel.up * speed + new Vector3(15f, 0f, 0f));
                    spawnedBullet2.AddForce(barrel2.up * speed + new Vector3(15f, 0f, 0f));
                    break;
                case 4:
                    spawnedBullet.AddForce(barrel.up * speed + new Vector3(45f, 0f, 0f));
                    spawnedBullet2.AddForce(barrel2.up * speed + new Vector3(45f, 0f, 0f));
                    break;
                case 5:
                    spawnedBullet.AddForce(barrel.up * speed + new Vector3(90f, 0f, 0f));
                    spawnedBullet2.AddForce(barrel2.up * speed + new Vector3(90f, 0f, 0f));
                    break;
            }
        }
    }
}