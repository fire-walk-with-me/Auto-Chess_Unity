using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

//This script inherits from Unit. It decides that a unit has the ranged fighting style

public class Range : Unit
{
    [SerializeField] GameObject projectile;

    public override void attackTarget()
    {
        //play animation

        //GameObject p = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        //p.GetComponent<projectile>().ShootTarget(target);
    }
}
