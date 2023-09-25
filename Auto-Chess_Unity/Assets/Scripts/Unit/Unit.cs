using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected Stats stats;
    [SerializeField] protected Ability ability;
    protected AI ai;
    [SerializeField] protected bool isDead;
    [SerializeField] protected GameObject target;

    [SerializeField] protected float mana;
    [SerializeField] protected float health;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    public GameObject GetTarget()
    {
        return target;
    }
    public bool IsDead() => isDead;
    public Stats Stats() => stats;
    public float Health() => health;
    public float Mana() => mana;
}
