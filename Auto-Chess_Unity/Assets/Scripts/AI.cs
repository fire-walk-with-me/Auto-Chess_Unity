using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] Behaviour activeBehaviour;
    Unit unit;

    private void Start()
    {
        gameObject.AddComponent<Target>();
        gameObject.AddComponent<Attack>();
        gameObject.AddComponent<Move>();
        gameObject.AddComponent<UseAbility>();
        unit = gameObject.GetComponent<Unit>();
    }

    public Behaviour GetActiveBehaviour()
    {
        return activeBehaviour;
    }

    private void setActiveBehaviour(Behaviour behaviour)
    {
        activeBehaviour = behaviour;
    }

    public void SimpleDecisionTree()
    { 
        if (!unit.GetTarget() || deadTarget()) activeBehaviour = gameObject.GetComponent<Target>();

        else if(Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) > unit.Stats().GetStat("attackDistance"))
            activeBehaviour = gameObject.GetComponent<Move>();

        else if(Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) <= unit.Stats().GetStat("attackDistance") && 
            unit.Mana() >= unit.Stats().GetStat("maxMana"))
            activeBehaviour = gameObject.GetComponent<UseAbility>();

        else if(Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) <= unit.Stats().GetStat("attackDistance") &&
            unit.Mana() < unit.Stats().GetStat("maxMana")) 
            activeBehaviour = gameObject.GetComponent<Attack>();

        activeBehaviour.DoAction();
    }

    private bool deadTarget()
    {
        return unit.GetTarget().GetComponent<Unit>().IsDead();
    }
}
