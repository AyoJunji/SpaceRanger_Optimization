using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomber : MonoBehaviour
{
    int damage = 1;
    public GameObject projectile;
    public GameObject projectile2;
    public Transform muzzlePoint;
    public Transform muzzlePoint2;

    float duration = .5f;
    float delay = 3f;
    int speed;

    void Start()
    {
        speed = Random.Range(2, 10);

        StartCoroutine(ShootProjectile(delay));
    }

    void Update()
    {
        transform.position = new Vector3(-8 + Mathf.PingPong(Time.time * speed, 16), transform.position.y - .0005f, transform.position.z);
    }

    IEnumerator ShootProjectile(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        Instantiate(projectile, muzzlePoint.position, Quaternion.identity);
        Instantiate(projectile2, muzzlePoint2.position, Quaternion.identity);
        StartCoroutine(ShootProjectile(delay));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.TakeDamage(damage);

            HandleDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Projectiles")
        {
            HandleDeath();
        }
    }

    void HandleDeath()
    {
        StartCoroutine(DelayDeath(duration));
    }

    IEnumerator DelayDeath(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
