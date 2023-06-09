using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{

    public int damage = 1;
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
