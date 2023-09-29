using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will find the closest enemy to the unit who uses this behaviour

public class Target : AIBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool belongsToPlayer;
    [SerializeField] List<GameObject> targetList = new List<GameObject>();
    [SerializeField] GameObject closestTarget;
    private void Start()
    {
        if(gameObject.tag == "Player") belongsToPlayer = true;
    }

    public override void DoAction()
    {
        target = getClosestEnemy();

        targetEnemy();
    }

    private GameObject getClosestEnemy()
    {
        
        if (belongsToPlayer)
        {
            targetList = competitor.GetCharacters();
        }
        else
        {
            targetList = player.GetCharacters();
        }
        closestTarget = targetList[0];

        foreach(GameObject enemy in targetList)
        {
            if(Vector3.Distance(thisUnit.transform.position, enemy.transform.position) <= Vector3.Distance(thisUnit.transform.position, closestTarget.transform.position))
                closestTarget = enemy;
        }
        return closestTarget;
    }
    public void targetEnemy()
    {
        thisUnit.SetTarget(target);
    }
}
