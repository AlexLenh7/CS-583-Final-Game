using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // hp of the Enemy
    public int currHP;
    public int maxHP = 100;

    // move speed of the Enemy 
    public float moveSpeed = 3f;

    // use to find player
    private Transform player;

    // rotation speed of the Enemy
    public float rotationSpeed = 10f;

    // time in between shots
    public float attackCD = 0f;
    public float minTimeShots = 3f;
    public float maxTimeShots = 7f;

    // bullet prefabs to use as a set of GameObjects
    public GameObject[] bullets;
    
    // firepoint to spawn bullets
    public Transform firePoint;
    public bool BossDead = false;

    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    void Awake() {
        // follows player
        player = GameObject.FindGameObjectWithTag("PlayerChar").transform;
        Debug.Log("Enemy HP: " + currHP);
        attackCD = Random.Range(minTimeShots, maxTimeShots);
    }

    void FixedUpdate()
    {
        MoveToPlayer();
        RotateTowardsPlayer();
        
        // Attack player
        attackCD -= Time.fixedDeltaTime;
        if (attackCD <= 0f)
        {
            Attack();
            attackCD = Random.Range(minTimeShots, maxTimeShots);
        }

    }

    void MoveToPlayer()
    {
    // Find direction to player
    Vector3 moveDirection = (player.position - transform.position).normalized;

    // Move enemy
    transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // enemy attack
    void Attack(){
    // Randomly select a bullet from the array
    int randomBullet = Random.Range(0, bullets.Length);
    //Debug.Log(bullets[randomBullet].name);
    GameObject bullet = Instantiate(bullets[randomBullet], firePoint.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 270, 0));

    // lock bullet y rotation to enemy y rotation
    bullet.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 270, 0);

    }
    void RotateTowardsPlayer(){  
    // Find direction to player
    Vector3 direction = (player.position - transform.position).normalized;

    // Calculate rotation towards player
    Quaternion targetRotation = Quaternion.LookRotation(direction);

    // Smoothly rotate towards the player
    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }

    public void TakeDamage(int damage)
    {
        currHP -= damage;
        Debug.Log("Enemy took " + damage + " damage. Current health: " + currHP);

        if (currHP <= 0)
        {
            Debug.Log("Boss health reached 0.");
            BossDead = true;
            Debug.Log("BossDead set to true.");
            
            Debug.Log("Checking GameManager...");
            if (gameManager != null)
            {
                Debug.Log("GameManager is assigned. Calling Victory...");
                gameManager.Victory();
            }
            else
            {
                Debug.LogError("GameManager is null! Cannot call Victory.");
            }

            Debug.Log("Destroying boss object.");
            Destroy(gameObject);
        }
    }
}