using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //movement variables
    public Transform player;
    public float smooth = 0.1225f;
    public float height = 12;

    private Vector3 velocity = Vector3.zero;

    //Methods
    void Update()
    {

        Vector3 pos = new Vector3();

        transform.rotation = Quaternion.Euler(50, 0, 0);

        //movement
        pos.x = player.position.x;
        pos.z = player.position.z + -10f;
        pos.y = player.position.y + height;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);

    }
}