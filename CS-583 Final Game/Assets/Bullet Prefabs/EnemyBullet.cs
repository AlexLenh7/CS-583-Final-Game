using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int damage;
    [SerializeField] float lifeTime; //time before bullet self destructs naturally
    [SerializeField] float speed; //speed of bullet
    [SerializeField] bool isWave = false;
    private int numCollisions = 0;
    private Rigidbody rb;

    void Start()
    {
        //Bullet will begin not moving

        rb = GetComponent<Rigidbody>();
        if (gameObject)
        {
            Destroy(gameObject, lifeTime);
        }   

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moves the bullet upwards in the direction based on the orientation of the bullet.
        rb.velocity = transform.up * speed;

        if (isWave == true && transform.localScale.x > 0)
        {
            transform.localScale -= new Vector3(.1f, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        }

    }

    //Will run after the specified amount of seconds in Invoke("selfDestruct", time)
    //Destroys the bullet if it has not hit anything to clear clutter.

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        //Check for what the bullet hit and react accordingly

        //If the bullet is a wave, use this path of behavior
        if (isWave == true)
        {
            if (collidedWith.CompareTag("PlayerChar"))
            {
                //Alex did not add health yet so keep this commented until he adds it.
                //collidedWith.GetComponent<PlayerMovement>().CurrHP -= damage;

                Destroy(gameObject);
            }
        }
        else //Otherwise, use normal bullet behavior
        {
            //If it hits a player, deal damage and self destruct
            if (collidedWith.CompareTag("PlayerChar"))
            {
                //Alex did not add health yet so keep this commented until he adds it.
                //collidedWith.GetComponent<PlayerMovement>().CurrHP -= damage;

                Destroy(gameObject);
            }
            else if (collidedWith.CompareTag("Obstacle")) // If it hits anything else, self destruct.
            {
                Destroy(gameObject);
            }
        }

    }
}
