using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    private int currentHealth;
    private int maxHealth = 5;
    public Transform muzzlePoint;

    [Header("Assignables")]
    GameObject playerObj;
    public GameObject projectile;
    Rigidbody2D playerRB;
    public Image Health1, Health2, Health3, Health4;

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
        switch (currentHealth)
        {
            case 0:
                SceneManager.LoadScene("TitleScreen");
                break;
            case 1:
                Destroy(Health1);
                break;
            case 2:
                Destroy(Health2);
                break;
            case 3:
                Destroy(Health3);
                break;
            case 4:
                Destroy(Health4);
                break;
            default:
                SceneManager.LoadScene("TitleScreen");
                break;
        }

    }
}