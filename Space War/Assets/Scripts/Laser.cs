using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField] float LaserSpeed = 15f;
    [SerializeField] float projectileFiringPeriod = 0.3f;
    [SerializeField] float OrangeLaserRangeX = 0.3f;
    [SerializeField] AudioClip shotSound;

    public float GetLaserSpeed() { return LaserSpeed; }
    public float GetProjectileFiringPeriod() { return projectileFiringPeriod; }

    bool LaserSide = false;
    float xPositionGreenLaser = 0.4f;
    float xPositionYellowLaser = 0.4f;


    public void shot(string name, Vector3 position)
    { 
        switch (name)
        {
            case "LaserOrange1":
                OrangeLaser1(position);
                break;
            case "LaserYellow1":
                YellowLaser_1_2(position,1);
                break;
            case "LaserYellow2":
                YellowLaser_1_2(position, 2);
                break;
            case "LaserYellow3":
                YellowLaser_1_2(position, 2);
                break;
            case "LaserGreen1":
                LaserGreen1(position);
                break;
            case "LaserGreen2":
                LaserGreen2(position);
                break;
            case "LaserGreen3":
                LaserGreen3(position);
                break;
            case "LaserPurple1":
                LaserPurple1(position);
                break;
            default:
                break;
        }
    }

    private void LaserPurple1(Vector3 position)
    {
        GameObject laserObject1 = Instantiate(gameObject, new Vector3(position.x, position.y, position.z), Quaternion.identity) as GameObject;
        laserObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -GetLaserSpeed());
        laserObject1.transform.eulerAngles = new Vector3(0, 0, UnityEngine.Random.Range(0,90));
    }

    private void LaserGreen3(Vector3 position)
    {
        GameObject laserObject1 = Instantiate(gameObject, new Vector3(position.x, position.y+0.3f, position.z), Quaternion.identity) as GameObject;
        laserObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());
        GameObject laserObject2 = Instantiate(gameObject, new Vector3(position.x - xPositionGreenLaser, position.y, position.z), Quaternion.identity) as GameObject;
        laserObject2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());
        GameObject laserObject3 = Instantiate(gameObject, new Vector3(position.x + xPositionGreenLaser, position.y, position.z), Quaternion.identity) as GameObject;
        laserObject3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());
    }

    private void LaserGreen2(Vector3 position)
    {
        GameObject laserObject1 = Instantiate(gameObject, new Vector3(position.x-xPositionGreenLaser, position.y, position.z), Quaternion.identity) as GameObject;
        laserObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());
        GameObject laserObject2 = Instantiate(gameObject, new Vector3(position.x+xPositionGreenLaser, position.y, position.z), Quaternion.identity) as GameObject;
        laserObject2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());
    }

    private void LaserGreen1(Vector3 position)
    {
        GameObject laserObject1 = Instantiate(gameObject, new Vector3(position.x , position.y, position.z), Quaternion.identity) as GameObject;
        laserObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());
    }

    private void YellowLaser_1_2(Vector3 position, int control) //control 1 = yellowLaser1, control 2 = yellowLaser2
    {
            
        if (LaserSide || control== 2)
        {
            GameObject laserObject1 = null;
            laserObject1 = Instantiate(gameObject, new Vector3(position.x - xPositionYellowLaser, position.y, position.z), Quaternion.identity) as GameObject;
            laserObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());

        }
        if (!LaserSide || control == 2)
            {
            GameObject laserObject2 = null;
            laserObject2 = Instantiate(gameObject, new Vector3(position.x + xPositionYellowLaser, position.y, position.z), Quaternion.identity) as GameObject;
            laserObject2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());
        }
        LaserSide = !LaserSide;
    }
    private void OrangeLaser1(Vector3 position)
    {
            GameObject laserObject;
            if (LaserSide)
            {
                laserObject = Instantiate(gameObject, new Vector3(position.x - OrangeLaserRangeX, position.y, position.z), Quaternion.identity) as GameObject;
                LaserSide = false;
            }
            else
            {
                laserObject = Instantiate(gameObject, new Vector3(position.x + OrangeLaserRangeX, position.y, position.z), Quaternion.identity) as GameObject;
                LaserSide = true;
            }
            laserObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -GetLaserSpeed());

            if (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x < transform.position.x && Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x > transform.position.x)
            {
                AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position, 0.01f);
            }
        
    }
}