using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTwo : MonoBehaviour
{
    private float timer; // Timer for tracking time passed
    private float time;
    public float roundEnd;
    public float roundStart;
    private float enemyfrq;
    private float randNum = 0;
    public GameObject enemy;
    public Transform enemyPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // While time is within the round start and end period, make the portal appear at y = 2
        if (time > roundStart && time < roundEnd)
        {

            // Teleport the portal to y = 2 (appears)
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);

            enemyfrq += Time.deltaTime;
            // Every 1 second, check for enemy spawn
            if (enemyfrq > 1)
            {
                // Generates a random number and checks it
                randNum = Random.Range(1, 30);
                if (randNum == 1)
                {
                    // Spawns the enemy at a specified location
                    Instantiate(enemy, enemyPos.position, Quaternion.identity);
                }
                // Resets the 1 second timer for enemy frequency
                enemyfrq = 0;
            }

        }
        else
        {
            // Teleport the portal to y = -50 (disappears)
            transform.position = new Vector3(transform.position.x, -50f, transform.position.z);

        }
    }
}
