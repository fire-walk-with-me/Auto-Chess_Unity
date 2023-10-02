using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private string unitName;
    protected Stats stats;
    [SerializeField] protected Ability ability;
    protected AI ai;
    [SerializeField] protected bool isDead;
    [SerializeField] protected GameObject target;

    [SerializeField] protected float mana;
    [SerializeField] protected float health;

    void Start()
    {
        stats = GetComponent<Stats>();
        health = stats.GetStat("maxHealth");
        mana = stats.GetStat("maxMana");
    }

    private void Update()
    {
        if (health <= 0)
        {
            isDead = true;
        }

        RegenrateMana();

    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    public void RemoveTarget()
    {
        target = null;
    }
    public GameObject GetTarget()
    {
        return target;
    }
    public bool IsDead() => isDead;
    public Stats Stats() => stats;
    public float Health() => health;
    public float Mana() => mana;
    public string UnitName() => unitName;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void TakeMana()
    {
        mana -= mana;
    }

    private void RegenrateMana()
    {
        mana += (stats.GetStat("manaRegen") * Time.deltaTime) / 5;
    }
}
