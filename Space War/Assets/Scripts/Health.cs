using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int health = 100;
    [SerializeField] AudioClip deathSound;

    DeadAnimation deadAnim;
    Points points;
    bool IsAlive = true;

    void Start()
    {
        points= FindObjectOfType<Points>();

        deadAnim = gameObject.GetComponent<DeadAnimation>();
    }
  
    public int getHealth()
    {
        return health;
    }
    public bool getAlive()
    {
        return IsAlive;
    }
    public void setHealth(int health_)
    {
        health = health_;
    }
    public void setIsAlive(bool isAlive_)
    {
        IsAlive = isAlive_;
    }

   public void IsAliveNow(int pointsForKill)
    {
        if (getHealth() <= 0 && getAlive())
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, (UnityEngine.Random.Range(1, 100) / 100f));
           
            deadAnim.RunDeadAnimation();
            Destroy(gameObject, 1f);
            if (gameObject.name == "Player")
            {
                FindObjectOfType<Scene_Manager>().LoadGameOver();
            }
            else
            {
                points.AddScore(pointsForKill);
            }
            IsAlive = false;

        }
    }

    public void HealthDown(int damage)
    {
        health -= damage;
    }
}
