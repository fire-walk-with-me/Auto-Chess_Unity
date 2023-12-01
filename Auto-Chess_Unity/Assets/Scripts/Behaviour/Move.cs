using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Move : AIBehaviour
{
    [SerializeField] Vector3 heading;
    [SerializeField] Vector3 direction;
    [SerializeField] float distanceToTarget;

    public override void DoAction()
    {
        CalculateDirection();

        animator.SetBool("Walking", true);
        animator.SetBool("Attacking", false);
        gameObject.transform.position += direction * Time.deltaTime * 4;
    }

    private void CalculateDirection()
    {
        heading = thisUnit.GetTarget().transform.position - transform.position;
        distanceToTarget = heading.magnitude;
        direction = heading / distanceToTarget;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
    }
}
