using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will find the closest enemy to the unit who uses this behaviour

public class Target : Behaviour
{
    [SerializeField] GameObject target;
    
    public override void DoAction()
    {
        if (competitor.getActiveCharacterAmount() <= 0) return;

        target = getClosestEnemy();

        targetEnemy();
    }

    private GameObject getClosestEnemy()
    {
        List<GameObject> list = competitor.getEnemyCharacters();
        GameObject closestTarget = list[0];

        foreach(GameObject enemy in list)
        {
            if(Vector3.Distance(thisUnit.transform.position, enemy.transform.position) <= Vector3.Distance(thisUnit.transform.position, closestTarget.transform.position))
                closestTarget = enemy;
        }
        return closestTarget;
    }
    public void targetEnemy()
    {
        thisUnit.GetComponent<Unit>().SetTarget(target);
    }
}
