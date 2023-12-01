using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//This script will cause the unit to attack its target on a interval based on the units attack-speed

public class Attack : AIBehaviour
{
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDamage;
    float attackTime = 10;
    float timer;

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
            StartCoroutine(AttackEnemy());
            timer = attackTime;
        }

        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", true);

        timer -= Time.deltaTime;
    }

    private IEnumerator AttackEnemy()
    {
        //Debug.Log(gameObject + " attacks for " + attackDamage + " Dmg");
        Unit enemy = thisUnit.GetTarget().GetComponent<Unit>();
        if(enemy.IsDead()) thisUnit.RemoveTarget();

        enemy.TakeDamage(attackDamage);
        yield return null;
    }
}
