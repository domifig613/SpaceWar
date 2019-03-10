using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnimation : MonoBehaviour {

    public Animator SpaceShip;

    public void RunDeadAnimation()
    {
        SpaceShip.SetInteger("WhichAnimation", UnityEngine.Random.Range(1,4));
        
    }
}
