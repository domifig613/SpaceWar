using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //config parameters
    [Header("Player Movment")]
    [SerializeField] float howFastHorizontal = 20;
    [SerializeField] float howFastVertial = 15;

    [Header("Projectile")]
    [SerializeField] float Padding = 0.5f;
    [SerializeField] float yMaxHigh = 0.4f;
    [SerializeField] GameObject laser;

     

    bool isDelay = false;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    Health healPlayer;

    // Use this for initialization
    void Start () {
        SetUpMoveBoundaries();
        healPlayer = gameObject.GetComponent<Health>();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x        + Padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x        - Padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y        + Padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, yMaxHigh, 0)).y - Padding;
    }

    // Update is called once per frame
    void Update () {
        if (healPlayer.getAlive())
        {
            Move();
            Fire();
        }
	}

    private void Fire()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            isDelay = true;
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireContinously());
            return;
        }
    
    }

    IEnumerator FireContinously()
    {
        while (!isDelay)
        {
            laser.GetComponent<Laser>().shot(laser.name, transform.position);
            yield return new WaitForSeconds(laser.GetComponent<Laser>().GetProjectileFiringPeriod());
        }
        isDelay = false;
    }

    private void Move()
    {
        transform.position = new Vector2(MoveHorizontal(), MoveVertical());
    }

    private float MoveHorizontal()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX * howFastHorizontal, xMin, xMax);
        return newXPos;
    }
    private float MoveVertical()
    {
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime;
        float newYPos = Mathf.Clamp(transform.position.y + deltaY * howFastVertial, yMin, yMax);
        return newYPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        healPlayer.HealthDown(damageDealer.GetDamage()); //space ship get damage
        healPlayer.IsAliveNow();                         //check isAlive  space ship?
        damageDealer.Hit();
    }
}
