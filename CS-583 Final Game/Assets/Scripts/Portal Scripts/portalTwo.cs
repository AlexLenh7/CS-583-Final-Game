using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTwo : MonoBehaviour
{
    private Collider collider;
    public float alphaLvl = 0f; // Use float for alphaLvl
    private float timer; // Timer for tracking time passed
    private float time;
    public float roundEnd;
    public float roundStart;
    private float enemyfrq;
    private float randNum = 0;
    public GameObject enemy;
    public Transform enemyPos;

    private Renderer portalRenderer; // To reference the Renderer component
    private Material portalMaterial; // To reference the Material of the object

    void Start()
    {
        //gets collider of object
        collider = GetComponent<Collider>();
        portalRenderer = GetComponent<Renderer>();
        portalMaterial = portalRenderer.material;
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //while time is less than 5
        if (time > roundStart && time < roundEnd)
        {
            //enables 
            collider.enabled = true;
            enemyfrq += Time.deltaTime;
            //every 60 seconds boss will spawn and the time will reset
            if (enemyfrq > 1)
            {
                //the next two lines generates the number and checks it 
                //creating a 1 in 30 chance every second for a spawner to make an enemy
                randNum = Random.Range(1, 30);
                if (randNum == 1)
                {
                    //spawns the enemy at a specified location
                    Instantiate(enemy, enemyPos.position, Quaternion.identity);
                }
                // resets 1 second timer
                enemyfrq = 0;
            }
            timer += Time.deltaTime; // Increment timer by frame time
            if (timer >= .02f) // Check if .05 seconds have passed
            {
                alphaLvl += 0.01f; // Decrease alphaLvl by 0.1
                alphaLvl = Mathf.Clamp(alphaLvl, 0f, 1f); // Make sure alphaLvl stays within 0 to 1

                // Get the current color of the material
                Color currentColor = portalMaterial.color;

                // Set the new color with the same RGB values but updated alpha
                portalMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, alphaLvl);


                timer = 0f; // Reset the timer
            }
        }
        else
        {
            //keeps track of time passing
            timer += Time.deltaTime; 
            if (timer >= .02f) // Check if .05 seconds have passed
            {
                //Turns off collider
                collider.enabled = false;
                alphaLvl -= 0.01f; // Decrease alphaLvl by 0.1
                alphaLvl = Mathf.Clamp(alphaLvl, 0f, 1f); // Make sure alphaLvl stays within 0 to 1
                
                // Get the current color of the material
                Color currentColor = portalMaterial.color;

                // Set the new color with the same RGB values but updated alpha
                portalMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, alphaLvl);


                timer = 0f; // Reset the timer
            }
        }
    }
}