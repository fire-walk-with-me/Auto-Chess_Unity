using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] AIBehaviour activeBehaviour;
    [SerializeField] PlayerAI playerAI;
    [SerializeField] PlayerHuman playerHuman;
    Unit unit;

    private void Awake()
    {
        playerAI = FindObjectOfType<PlayerAI>().GetComponent<PlayerAI>();
        playerHuman = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        gameObject.AddComponent<Target>();
        gameObject.AddComponent<Attack>();
        gameObject.AddComponent<Move>();
        gameObject.AddComponent<UseAbility>();
        unit = gameObject.GetComponent<Unit>();
    }
    private void Update()
    {
        SimpleDecisionTree();
    }
    public AIBehaviour GetActiveBehaviour()
    {
        return activeBehaviour;
    }

    private void setActiveBehaviour(AIBehaviour behaviour)
    {
        activeBehaviour = behaviour;
    }

    public void SimpleDecisionTree()
    { 
        if (!unit.GetTarget() || deadTarget()) activeBehaviour = gameObject.GetComponent<Target>();

        else if(Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) - 0.2f > unit.Stats().GetStat("attackDistance"))
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

    public PlayerAI GetAIPlayer()
    {
        return playerAI;
    }

    public PlayerHuman GetHumanPlayer()
    {
        return playerHuman;
    }
}
