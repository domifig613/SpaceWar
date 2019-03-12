using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [SerializeField] int damage = 100;
    [SerializeField] int random_plus_minus_damage = 10;
    string[] laserTabel= { "LaserOrange1(Clone)", "LaserYellow1(Clone)", "LaserYellow2(Clone)", "LaserPurple1(Clone)", "LaserYellow3(Clone)" }; //laser destroyed if hit

    void Start()
    {
        foreach (string laser in laserTabel)
        {
            if (laser == gameObject.name)
            {
                destroy = true;
                break;
            }
        }
    }


    bool destroy = false;
    public int GetDamage()
    {
        int random_damage = UnityEngine.Random.Range(-random_plus_minus_damage, random_plus_minus_damage + 1);
        return damage+random_damage;
    }

    public void Hit()
    {
        if (destroy)
        {
            Destroy(gameObject);
        }
    }

}
