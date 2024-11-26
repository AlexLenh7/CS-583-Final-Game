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
    public GameObject enemy;
    public Transform enemyPos;

    void Start()
    {
        //gets collider of object
        collider = GetComponent<Collider>();

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
            if (time + 5 == roundStart)
            {
                Instantiate(enemy, enemyPos.position, Quaternion.identity);
            }
            timer += Time.deltaTime; // Increment timer by frame time
            if (timer >= .02f) // Check if .05 seconds have passed
            {
                alphaLvl += 0.01f; // Decrease alphaLvl by 0.1
                alphaLvl = Mathf.Clamp(alphaLvl, 0f, 1f); // Make sure alphaLvl stays within 0 to 1

                Color currentColor = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, alphaLvl);
                timer = 0f; // Reset the timer
            }
        }
        else
        {
            timer += Time.deltaTime; // Increment timer by frame time
            if (timer >= .02f) // Check if .05 seconds have passed
            {
                collider.enabled = false;
                alphaLvl -= 0.01f; // Decrease alphaLvl by 0.1
                alphaLvl = Mathf.Clamp(alphaLvl, 0f, 1f); // Make sure alphaLvl stays within 0 to 1

                Color currentColor = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, alphaLvl);

                timer = 0f; // Reset the timer
            }
        }
    }
}
