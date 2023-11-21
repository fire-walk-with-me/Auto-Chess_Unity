using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float maxMana;
    [SerializeField] float manaRegen;
    [SerializeField] float attack;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDistance;
    [SerializeField] float defence;

    private void Start()
    {
        RandomizeStats();
    }

    public float GetStat(string stat)
    {
        if (stat == "maxHealth") return maxHealth;
        if (stat == "maxMana") return maxMana;
        if (stat == "manaRegen") return manaRegen;
        if (stat == "attack") return attack;
        if (stat == "attackSpeed") return attackSpeed;
        if (stat == "attackDistance") return attackDistance;
        if (stat == "defence") return defence;
        else return 0;
    }

    private void RandomizeStats()
    {
        //Add a way that rarity affect stats

        if (gameObject.GetComponent<Melee>())//Melee
        {
            maxHealth = Random.Range(20, 31);
            maxMana = Random.Range(10, 16);
            manaRegen = Random.Range(2, 8);
            attack = Random.Range(5, 8);
            attackSpeed = Random.Range(2, 5);
            attackDistance = Random.Range(1, 1.5f);
            defence = Random.Range(1, 4);
        }
        else if (gameObject.GetComponent<Range>())//Range
        {
            maxHealth = Random.Range(15, 21);
            maxMana = Random.Range(10, 16);
            manaRegen = Random.Range(2, 8);
            attack = Random.Range(4, 7);
            attackSpeed = Random.Range(3, 6);
            attackDistance = Random.Range(8, 14);
            defence = Random.Range(1, 3);
        }
    }
}
