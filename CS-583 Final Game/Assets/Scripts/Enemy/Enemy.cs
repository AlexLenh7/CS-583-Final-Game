using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    // bullet prefabs to use as a set of GameObjects
    public GameObject[] bullets;
    
    // firepoint to spawn bullets
    public Transform firePoint;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("PlayerChar").transform;
    }

    void FixedUpdate()
    {
        MoveToPlayer();
        RotateTowardsPlayer();
        
        // Attack player occasionally
        if (Random.value < 0.01f)
        {
            Attack();
        }
    }

    void MoveToPlayer()
    {
    // Find direction to player
    Vector3 moveDirection = (player.position - transform.position).normalized;

    // Move enemy
    transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // enemy attack function
    // It should rotate the bullet prefab's Y rotation to the enemy's Y rotation upon spawning.
    // can be random
    // can be a shotgun
    void Attack(){
    // Randomly select a bullet from the array
    int randomBullet = Random.Range(0, bullets.Length);
    Debug.Log(bullets[randomBullet].name);
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
}
