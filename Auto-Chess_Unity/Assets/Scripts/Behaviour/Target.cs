using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will find the closest active enemy to the unit who uses this behaviour, and set it as a target

public class Target : AIBehaviour
{
    //[SerializeField] GameObject target;
    [SerializeField] bool belongsToPlayer;
    [SerializeField] List<GameObject> targetList = new List<GameObject>();
    [SerializeField] GameObject closestTarget;
    private void Start()
    {
        targetList.Clear();
        if (gameObject.tag == "Player") belongsToPlayer = true;
    }

    public override void DoAction()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", false);
        targetEnemy(getClosestEnemy());
    }

    private GameObject getClosestEnemy()
    {
        if (belongsToPlayer)
        {
            targetList = competitor.GetActiveCharacters();
        }
        else
        {
            targetList = player.GetActiveCharacters();
        }

        closestTarget = null;

        for (int i = 0; i < targetList.Count; i++)
        {
            if (targetList[i].GetComponent<Unit>().IsDead()) continue;

            closestTarget = targetList[i];
        }

        if (closestTarget == null) return closestTarget;

        foreach (GameObject enemy in targetList)
        {
            if (enemy.GetComponent<Unit>().IsDead()) continue;
            if (Vector3.Distance(thisUnit.transform.position, enemy.transform.position) <= Vector3.Distance(thisUnit.transform.position, closestTarget.transform.position))
                closestTarget = enemy;
        }
        return closestTarget;
    }
    public void targetEnemy(GameObject target)
    {
        thisUnit.SetTarget(target);
    }
}
