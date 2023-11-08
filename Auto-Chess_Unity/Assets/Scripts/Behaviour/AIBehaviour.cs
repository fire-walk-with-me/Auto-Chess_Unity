using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is the abstract class that the different behaviours inherit from

public abstract class AIBehaviour : MonoBehaviour
{
    protected PlayerAI competitor;
    protected PlayerHuman player;
    protected AI aiModel;
    protected Unit thisUnit;
    protected Animator animator;

    private void Awake()
    {
        aiModel = gameObject.GetComponent<AI>();
        competitor = aiModel.GetAIPlayer();
        player = aiModel.GetHumanPlayer();
        thisUnit = gameObject.GetComponent<Unit>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public virtual void DoAction() { }
}
