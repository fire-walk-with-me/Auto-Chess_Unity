using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

//This script inherits from Unit. It decides that a unit has the ranged fighting style

public class Range : Unit
{
    [SerializeField] GameObject arrow;
    Vector3 heading;
    Vector3 direction;
    float distanceToTarget;

    public void ShootArrow()
    {
        if (GameInfo.Info.GetIsRoundActive())
        {
            projectile p = Instantiate(arrow, transform.position, CalculateDirection()).GetComponent<projectile>();
            p.SetTarget(GetTarget());
        }
    }

    private Quaternion CalculateDirection()
    {
        if (!GetTarget()) return Quaternion.LookRotation(direction);

        heading = GetTarget().transform.position - transform.position;
        distanceToTarget = heading.magnitude;
        direction = heading / distanceToTarget;
        return Quaternion.LookRotation(direction);
    }
}
