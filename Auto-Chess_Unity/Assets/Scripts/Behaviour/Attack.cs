using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Attack : AIBehaviour
{
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDamage;
    float timer;

    private void Start()
    {
        attackDamage = gameObject.GetComponent<Stats>().GetStat("attack");
        attackSpeed = gameObject.GetComponent<Stats>().GetStat("attackSpeed");
    }

    public override void DoAction()
    {
        if (timer <= 0) 
        {
            StartCoroutine(AttackEnemy());
            timer = attackSpeed;
        }

        if (thisUnit.GetTarget().GetComponent<Unit>().IsDead())
        {
            thisUnit.RemoveTarget();
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator AttackEnemy()
    {
        yield return new WaitForSeconds(attackSpeed);

        Debug.Log(gameObject + " attacks for " + attackDamage + " Dmg");
    }
}
