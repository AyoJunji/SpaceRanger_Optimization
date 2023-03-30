using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    GameObject bulletObj;
    Rigidbody2D bulletRB;
    public GameObject impactFX;

    public float bulletSpeed = 15;
    public float damage = 1f;
    private float duration = 1.5f;

    void Start()
    {
        bulletObj = this.gameObject;
        bulletRB = bulletObj.GetComponent<Rigidbody2D>();

        StartCoroutine(DelayedDeath(duration));
    }

    IEnumerator DelayedDeath(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        bulletRB.AddForce(transform.up * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy") 
        {
            Instantiate(impactFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Boss")
        {
            Instantiate(impactFX, transform.position, Quaternion.identity);
            Boss bossScript = collision.gameObject.GetComponent<Boss>();
            bossScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
