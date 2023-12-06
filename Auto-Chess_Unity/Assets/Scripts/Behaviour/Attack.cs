using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

//This script will cause the unit to attack its target on a interval based on the units attack-speed

public class Attack : AIBehaviour
{
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDamage;
    float attackTime = 10;
    float timer;

    Vector3 heading;
    Vector3 direction;
    float distanceToTarget;

    private void Start()
    {
        attackDamage = gameObject.GetComponent<Stats>().GetStat("attack");
        attackSpeed = gameObject.GetComponent<Stats>().GetStat("attackSpeed");
        attackTime -= attackSpeed;
    }

    public override void DoAction()
    {
        if (timer <= 0)
        {
            AttackEnemy();
            timer = attackTime;
        }

        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", true);

        timer -= Time.deltaTime;
    }

    private void AttackEnemy()
    {
        Unit enemy = thisUnit.GetTarget().GetComponent<Unit>();
        if (enemy.IsDead()) thisUnit.RemoveTarget();
        CalculateDirection();
        enemy.TakeDamage(attackDamage);
    }
    private void CalculateDirection()
    {
        heading = thisUnit.GetTarget().transform.position - transform.position;
        distanceToTarget = heading.magnitude;
        direction = heading / distanceToTarget;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
    }
}
