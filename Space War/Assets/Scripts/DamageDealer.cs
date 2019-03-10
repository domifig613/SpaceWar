using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

    [SerializeField] int damage = 100;
    [SerializeField] int random_plus_minus_damage = 10;

    public int GetDamage()
    {
        int random_damage = UnityEngine.Random.Range(-random_plus_minus_damage, random_plus_minus_damage + 1);
        return damage+random_damage;
    }

    public void Hit()
    {
        if (gameObject.name == "LaserGreen1(Clone)" || gameObject.name == "LaserOrange1(Clone)")
        {
            Destroy(gameObject);
        }
    }

}
