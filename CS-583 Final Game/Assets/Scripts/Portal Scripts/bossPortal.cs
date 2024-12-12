using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPortal : MonoBehaviour
{

    private float time;
    public float roundEnd;
    public float roundStart;
    private float enemyfrq;
    private float randNum = 0;
    private float bossCounter = 0;
    public GameObject enemy;
    public Transform enemyPos;


    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        // Teleport the portal to y = 2 (appears)
        transform.position = new Vector3(transform.position.x, 2f, transform.position.z);

        time += Time.deltaTime;
        //while time is less 
        if (time > roundStart && time < roundEnd)
        {
           
            if (time + 5 > roundStart && bossCounter == 0)
            {
                Instantiate(enemy, enemyPos.position, Quaternion.identity);
                bossCounter += 1;
            }
           
        }
        else
        {
            // Teleport the portal to y = -50 (disappears)
            transform.position = new Vector3(transform.position.x, -50f, transform.position.z);
        }
    }
}
