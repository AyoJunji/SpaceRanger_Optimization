using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    int damage = 1;
    float duration = .5f;

    int speed;
    private void Start()
    {
        speed = Random.Range(2, 10);
    }
    private void Update()
    {
        transform.position = new Vector3(-8 + Mathf.PingPong(Time.time * speed, 16), transform.position.y -.001f, transform.position.z);
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
        //explosion.Play();
        StartCoroutine(DelayDeath(duration));
    }

    IEnumerator DelayDeath(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}   
