using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private string unitName;
    protected Stats stats;
    protected AI ai;
    protected bool isDead;
    [SerializeField] protected GameObject target;

    protected float mana;
    protected float health;
    protected healthBar healthBar;
    [SerializeField] protected Ability ability;

    protected Vector3 startPosition;

    enum Rarity
    {
        common,
        rare,
        epic
    }

    void Start()
    {
        stats = GetComponent<Stats>();
        health = stats.GetStat("maxHealth");
        mana = stats.GetStat("maxMana");
        healthBar = gameObject.GetComponentInChildren<healthBar>();
        healthBar.SetMaxHealth(health);
        ai = gameObject.GetComponent<AI>();
    }

    private void Update()
    {
        RegenrateMana();
    }

    public virtual void attackTarget()
    {

    }

    public void SetStartingPosition(Vector3 startPos)
    {
        startPos = startPosition;
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

    public AI Ai() => ai;
    public string UnitName() => unitName;

    public void TakeDamage(float damage)
    {
        health -= (damage - stats.GetStat("defence"));
        healthBar.SetHealth(health);

        if (!isDead && health <= 0)
        {
            SetDead();
        }
    }

    public void TakeMana()
    {
        mana -= mana;
    }

    private void RegenrateMana()
    {
        if (mana < stats.GetStat("maxMana"))
            mana += (stats.GetStat("manaRegen") * Time.deltaTime) / 5;
    }

    public void SetDead()
    {
        isDead = true;
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
        foreach (SkinnedMeshRenderer smr in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            smr.enabled = false;
        }
        RemoveAsTarget(gameObject);
    }

    public void SetAlive()
    {
        isDead = false;
        health = stats.GetStat("maxHealth");
        healthBar.SetHealth(health);
        RemoveTarget();
        gameObject.GetComponentInChildren<Canvas>().enabled = true;
        foreach (SkinnedMeshRenderer smr in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            smr.enabled = true;
        }
    }

    public void ResetPoistion()
    {
        gameObject.transform.position = startPosition;
    }

    private void RemoveAsTarget(GameObject thisUnit)
    {
        if(!ai) ai = gameObject.GetComponent<AI>();

        foreach (GameObject go in ai.GetAIPlayer().GetCharacters())
        {
            Unit otherUnit = go.GetComponent<Unit>();
            if(otherUnit.GetTarget() == thisUnit)
                otherUnit.RemoveTarget();
        }

        foreach (GameObject go in ai.GetHumanPlayer().GetCharacters())
        {
            Unit unit = go.GetComponent<Unit>();
            if (unit.GetTarget() == thisUnit) 
                unit.RemoveTarget();
        }
    }
}
