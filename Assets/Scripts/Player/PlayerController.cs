using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private int bulletStorage;
    private int currentHealth;
    public int maxHealth;

    public Transform muzzlePoint;

    [Header("Assignables")]
    GameObject playerObj;
    public GameObject projectile;
    Rigidbody2D playerRB;
    Collider2D playerCollider;

    void Start()
    {
        playerObj = this.gameObject;
        playerRB = playerObj.GetComponent<Rigidbody2D>();
        playerCollider = playerObj.GetComponent<Collider2D>();

        currentHealth = maxHealth;
    }

    
    void Update()
    {
        float verticalDir = Input.GetAxis("Vertical");
        float horizontalDir = Input.GetAxis("Horizontal");

        Vector3 moveVec = new Vector3(horizontalDir, verticalDir, 0);
        moveVec = moveVec.normalized * moveSpeed * Time.deltaTime;
        playerRB.MovePosition(playerRB.transform.position + moveVec);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            HandleShooting();
        }
    }

    void HandleShooting()
    {
        if(bulletStorage <= 4)
        {
            Instantiate(projectile, muzzlePoint.position, Quaternion.identity);
            ++bulletStorage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentHealth -= 1;
    }
}
