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

    public GameObject singleShot;
    public GameObject Beam;
    public GameObject Burst;
    public GameObject Wind;

    public PlayerStats playerStats;


    private float cooldownTimerSingle = Mathf.Infinity;
    private float cooldownTimerBeam = Mathf.Infinity;
    private float cooldownTimerBurst = Mathf.Infinity;
    private float cooldownTimerWind = Mathf.Infinity;

    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimerSingle > attackCooldownSingle && playerStats.currentMana > 1)
            shootSingle();

        if (Input.GetKeyDown(KeyCode.Mouse1) && cooldownTimerBeam > attackCooldownBeam && playerStats.currentMana > 15)
            shootBeam();

        if (Input.GetKeyDown(KeyCode.Q) && cooldownTimerBurst > attackCooldownBurst && playerStats.currentMana > 10)
            shootBurst();
        
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimerWind > attackCooldownWind && playerStats.currentMana > 10)
            shootWind();

        cooldownTimerSingle += Time.deltaTime;
        cooldownTimerBeam += Time.deltaTime;
        cooldownTimerBurst += Time.deltaTime;
        cooldownTimerWind += Time.deltaTime;
    }

    void shootSingle()
    {
        Instantiate(singleShot, bulletSpawnPoint.transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 270, 0));
        cooldownTimerSingle = 0;
    }

    void shootBeam()
    {
        Instantiate(Beam, bulletSpawnPoint.transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 270, 0));
        cooldownTimerBeam = 0;
    }

    void shootBurst()
    {
        Instantiate(Burst, bulletSpawnPoint.transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 270, 0));
        cooldownTimerBurst = 0;
    }

    void shootWind()
    {
        Instantiate(Wind, bulletSpawnPoint.transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y + 270, 0));
        cooldownTimerWind = 0;
    }

}
