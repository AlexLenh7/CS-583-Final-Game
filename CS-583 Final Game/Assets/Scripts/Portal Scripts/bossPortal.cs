using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPortal : MonoBehaviour
{
    private Collider collider;
    public float alphaLvl = 0f; // Use float for alphaLvl
    private float timer; // Timer for tracking time passed
    private float time;
    public float roundEnd;
    public float roundStart;
    private float enemyfrq;
    private float randNum = 0;
    private float bossCounter = 0;
    public GameObject enemy;
    public Transform enemyPos;

    private Renderer portalRenderer; // To reference the Renderer component
    private Material portalMaterial; // To reference the Material of the object

    void Start()
    {
        //gets collider of object
        collider = GetComponent<Collider>();
        //gets the render component
        portalRenderer = GetComponent<Renderer>();

        //assighns 
        portalMaterial = portalRenderer.material;

    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //while time is less 
        if (time > roundStart && time < roundEnd)
        {
            //enables 
            collider.enabled = true;
            if (time + 5 > roundStart && bossCounter == 0)
            {
                Instantiate(enemy, enemyPos.position, Quaternion.identity);
                bossCounter += 1;
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
            timer += Time.deltaTime; // Increment timer by frame time
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
