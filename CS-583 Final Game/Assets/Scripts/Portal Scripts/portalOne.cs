using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOne : MonoBehaviour
{
    private Collider collider;
    public float alphaLvl = 1f; // Alpha level (no longer needed for teleportation, but leaving for clarity)
    private float timer; // Timer for tracking time passed
    private float time;
    public float roundEnd;
    private float enemyfrq;
    private float randNum = 0;
    public GameObject enemy;
    public Transform enemyPos;

    private Renderer portalRenderer; // To reference the Renderer component
    private Material portalMaterial; // To reference the Material of the object

    void Start()
    {
        // Gets collider of object
        collider = GetComponent<Collider>();

        // Gets the render component
        portalRenderer = GetComponent<Renderer>();

        // Assigns the material of the object
        portalMaterial = portalRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        // While time is less than roundEnd, run the game logic
        if (time < roundEnd)
        {
            // Enables collider
            collider.enabled = true;
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
            timer += Time.deltaTime; // Increment timer by frame time
            if (timer >= 0.02f) // Check if 0.02 seconds have passed
            {
                collider.enabled = false;

                // Instead of modifying alpha, teleport the object
                TeleportPortal(); // Call the teleport function

                timer = 0f; // Reset the timer
            }
        }
    }

    // Function to teleport the portal to y = -50
    void TeleportPortal()
    {
        transform.position = new Vector3(transform.position.x, -50f, transform.position.z); // Teleport to y = -50
    }
}
