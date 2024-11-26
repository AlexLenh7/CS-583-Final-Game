using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour
{
    // hp of the grunt
    public int currHP;
    public int maxHP = 100;

    // move speed of the grunt
    public float moveSpeed = 3f;

    // use to find player
    private Transform player;

    // rotation speed of the grunt
    public float rotationSpeed = 10f;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("PlayerChar").transform;
    }

    void FixedUpdate()
    {
        MoveToPlayer();
        RotateTowardsPlayer();
    }

    void MoveToPlayer()
{
    // Find direction to player
    Vector3 moveDirection = (player.position - transform.position).normalized;

    // Move enemy
    transform.position += moveDirection * moveSpeed * Time.deltaTime;
}

void RotateTowardsPlayer()
{
    // Find direction to player
    Vector3 direction = (player.position - transform.position).normalized;

    // Calculate rotation towards player
    Quaternion targetRotation = Quaternion.LookRotation(direction);

    // Smoothly rotate towards the player
    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
}
}
