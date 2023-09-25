using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    float maxHealth;
    float maxMana;
    float manaRegen;
    float attack;
    float attackSpeed;
    float attackDistance;
    float defence;

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
}
