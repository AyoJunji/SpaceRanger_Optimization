using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Vector3 targetPos;
    public float health = 200f;
    void Start()
    {
        
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
        health -= damage;

        if(health <= 0)
        {
            Destroy(this);
        }
    }
}