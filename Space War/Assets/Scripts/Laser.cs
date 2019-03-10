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

    public void shot(string name, Vector3 position)
    { 
        if (name == "LaserGreen1")
        {
            greenLaser1(position);
        }
        else if(name == "LaserOrange1")
        {
            OrangeLaser1(position);
        }
    }

    private void greenLaser1(Vector3 position)
    {
            GameObject laserObject;
            if (LaserSide)
            {
                laserObject = Instantiate(gameObject, new Vector3(position.x - xPositionGreenLaser, position.y, position.z), Quaternion.identity) as GameObject;
                LaserSide = false;
            }
            else
            {
                laserObject = Instantiate(gameObject, new Vector3(position.x + xPositionGreenLaser, position.y, position.z), Quaternion.identity) as GameObject;
                LaserSide = true;
            }
            laserObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetLaserSpeed());
    }
    private void OrangeLaser1(Vector3 position)
    {
        if (gameObject.gameObject.name == "LaserOrange1")
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
}