using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    private int currentHealth;
    public int maxHealth;

    public Transform muzzlePoint;

    [Header("Assignables")]
    GameObject playerObj;
    public GameObject projectile;
    Rigidbody2D playerRB;

    float verticalDir;
    float horizontalDir;
    void Start()
    {
        playerObj = this.gameObject;
        playerRB = playerObj.GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    
    void Update()
    {
        verticalDir = Input.GetAxis("Vertical");
        horizontalDir = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, muzzlePoint.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(horizontalDir, verticalDir) * moveSpeed;
        playerRB.velocity = Vector2.ClampMagnitude(playerRB.velocity, 12);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentHealth -= 1;
    }
}
