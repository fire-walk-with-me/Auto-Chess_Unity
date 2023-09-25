using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is the abstract class that the different behaviours inherit from

public abstract class Behaviour : MonoBehaviour
{
    [SerializeField] protected Competitor competitor;
    protected GameObject thisUnit;

    private void Awake()
    {
        competitor = FindObjectOfType<Competitor>().GetComponent<Competitor>();
        thisUnit = gameObject;
    }

    public virtual void DoAction() { }
}
