using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    //movement variables
    public Transform player;
    public float smooth = 0.1225f;

    //idk
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        //idk
        Vector3 pos = new Vector3();

        //movement
        pos.x = player.position.x;
        pos.z = player.position.z + -5.5f;
        pos.y = player.position.y + 10f;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);

    }
}