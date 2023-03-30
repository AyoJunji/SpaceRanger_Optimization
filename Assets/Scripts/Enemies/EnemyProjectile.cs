using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    GameObject bulletObj;
    Rigidbody2D bulletRB;
    Collider2D bulletColl;

    public float bulletSpeed = 15;
    public int damage = 1;
    private float duration = 1.5f;

    void Start()
    {
        bulletObj = this.gameObject;
        bulletRB = bulletObj.GetComponent<Rigidbody2D>();
        bulletColl = bulletObj.GetComponent<Collider2D>();

        StartCoroutine(DelayedDeath(duration));
    }

    IEnumerator DelayedDeath(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        bulletRB.AddForce(-transform.up * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
       {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
       }
    }
}
