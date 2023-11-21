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
        if (!playerAI) playerAI = FindObjectOfType<PlayerAI>().GetComponent<PlayerAI>();
        if (!playerHuman) playerHuman = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
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
            AIMODEL();

            if (!unit.IsDead()) activeBehaviour.DoAction(); //called each frame for every bot that is alive. Change the active behaviour through an AI-model

        }
    }
    public AIBehaviour GetActiveBehaviour()
    {
        return activeBehaviour;
    }

    private void SetActiveBehaviour(AIBehaviour behaviour)
    {
        activeBehaviour = behaviour;
    }

    public void AIMODEL()
    {
        if (!unit.GetTarget() || deadTarget()) SetActiveBehaviour(gameObject.GetComponent<Target>());

        else if (Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) - 0.2f > unit.Stats().GetStat("attackDistance"))
            SetActiveBehaviour(gameObject.GetComponent<Move>());

        else if (Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) <= unit.Stats().GetStat("attackDistance") &&
            unit.Mana() >= unit.Stats().GetStat("maxMana"))
            SetActiveBehaviour(gameObject.GetComponent<UseAbility>());

        else if (Vector3.Distance(gameObject.transform.position, unit.GetTarget().transform.position) <= unit.Stats().GetStat("attackDistance") &&
            unit.Mana() < unit.Stats().GetStat("maxMana"))
            SetActiveBehaviour(gameObject.GetComponent<Attack>());
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

    public void SetUnitIdle()
    {
        GetComponentInChildren<Animator>().SetBool("Walking", false);
        GetComponentInChildren<Animator>().SetBool("Attacking", false);
        SetActiveBehaviour(null);
    }
}
