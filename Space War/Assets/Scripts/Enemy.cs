using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float shotCounter;                //* for shot
    [SerializeField] float minTimeBetweenShots = 0.2f;//*
    [SerializeField] float maxTimeBetweenShots = 3f; //*
    [SerializeField] GameObject laser;
    [SerializeField] float Padding = 0.5f;
    [SerializeField] int pointsForKill;


    //[SerializeField][Range(0,1)] float deathSoundVolume = 0.7f;

    //to LiveAndDead
    Health healthScript;
    Camera gameCamera;


    float xMin;
    float xMax;
    // Use this for initialization
    void Start()
    {
        healthScript = gameObject.GetComponent<Health>();
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Padding;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.getAlive() && transform.position.x > xMin && transform.position.x < xMax)
        {
            CountDownAndShoot();
        }
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);//delay shot
        }
    }

    private void Fire()
    {
        laser.GetComponent<Laser>().shot(laser.name, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        healthScript.HealthDown(damageDealer.GetDamage()); //space ship get damage
        healthScript.IsAliveNow(pointsForKill);                         //check isAlive  space ship?
        damageDealer.Hit();
    }


}