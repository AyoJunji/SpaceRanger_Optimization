using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    GameObject bulletObj;
    Rigidbody2D bulletRB;
    Collider2D bulletColl;

    public float bulletSpeed = 15;

    void Start()
    {
        bulletObj = this.gameObject;
        bulletRB = bulletObj.GetComponent<Rigidbody2D>();
        bulletColl = bulletObj.GetComponent<Collider2D>();

    }

    void FixedUpdate()
    {
        bulletRB.AddForce(transform.up * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this);
    }
}
