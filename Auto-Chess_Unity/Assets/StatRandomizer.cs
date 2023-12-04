using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatRandomizer : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float maxMana;
    [SerializeField] float manaRegen;
    [SerializeField] float attack;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDistance;
    [SerializeField] float defence;

    ShopButton shopButton;
    private void Start()
    {
        shopButton = gameObject.GetComponent<ShopButton>();
    }
    public void RandomizeStats()
    {

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
