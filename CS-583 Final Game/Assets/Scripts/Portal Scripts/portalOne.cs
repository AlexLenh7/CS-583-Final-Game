using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOne : MonoBehaviour
{

    private float time;
    public float roundEnd;
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
        // While time is less than roundEnd, run the game logic
        if (time < roundEnd)
        {

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
                //teleport the object
                TeleportPortal(); // Call the teleport function
        }
    }

    // Function to teleport the portal to y = -50
    void TeleportPortal()
    {
        transform.position = new Vector3(transform.position.x, -50f, transform.position.z); // Teleport to y = -50
    }
}
