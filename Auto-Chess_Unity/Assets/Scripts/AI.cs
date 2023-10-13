using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] AIBehaviour activeBehaviour;
    [SerializeField] PlayerAI playerAI;
    [SerializeField] PlayerHuman playerHuman;
    RoundManager roundManager;
    Unit unit;

    private void Awake()
    {
        playerAI = FindObjectOfType<PlayerAI>().GetComponent<PlayerAI>();
        playerHuman = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        roundManager = FindObjectOfType<RoundManager>().GetComponent<RoundManager>();
        gameObject.AddComponent<Target>();
        gameObject.AddComponent<Attack>();
        gameObject.AddComponent<Move>();
        gameObject.AddComponent<UseAbility>();
        unit = gameObject.GetComponent<Unit>();
    }
    private void Update()
    {
        if (roundManager.ActiveRound())
        {
            SimpleDecisionTree();

            if (!unit.IsDead()) activeBehaviour.DoAction(); //called each frame for every bot that is alive. Change the active behaviour through an AI-model

        }
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
        if (!unit.GetTarget() || deadTarget()) setActiveBehaviour(gameObject.GetComponent<Target>());

        else if (Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) - 0.2f > unit.Stats().GetStat("attackDistance"))
            setActiveBehaviour(gameObject.GetComponent<Move>());

        else if (Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) <= unit.Stats().GetStat("attackDistance") &&
            unit.Mana() >= unit.Stats().GetStat("maxMana"))
            setActiveBehaviour(gameObject.GetComponent<UseAbility>());

        else if (Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) <= unit.Stats().GetStat("attackDistance") &&
            unit.Mana() < unit.Stats().GetStat("maxMana"))
            setActiveBehaviour(gameObject.GetComponent<Attack>());
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
