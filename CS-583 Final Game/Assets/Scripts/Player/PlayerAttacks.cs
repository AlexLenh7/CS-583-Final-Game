using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private float attackCooldownSingle;
    [SerializeField] private float attackCooldownBeam;
    [SerializeField] private float attackCooldownBurst;
    [SerializeField] private float attackCooldownWind;


    public GameObject bulletSpawnPoint;
    public float waitTime;
    
    public GameObject singleShot;
    public GameObject Beam;
    public GameObject Burst;
    public GameObject Wind;


    private float cooldownTimerSingle = Mathf.Infinity;
    private float cooldownTimerBeam = Mathf.Infinity;
    private float cooldownTimerBurst = Mathf.Infinity;
    private float cooldownTimerWind = Mathf.Infinity;

    void Update()
    {
        
        if (Input.GetMouseButton(0) && cooldownTimerSingle > attackCooldownSingle)
        {
            shootSingle();
        }
        cooldownTimerSingle += Time.deltaTime;

    }

    void shootSingle()
    {

        Instantiate(singleShot, bulletSpawnPoint.transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 270, 0));

        cooldownTimerSingle = 0;

    }


}
