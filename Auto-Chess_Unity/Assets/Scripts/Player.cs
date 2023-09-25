using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script holds information about the human player

public class Player : MonoBehaviour
{
    [SerializeField] int currency;
    [SerializeField] int characterLimit;
    [SerializeField] int activeCharacters;
    [SerializeField] float health;


    public void IncreaseGold(int gold)
    {
        currency += gold;
    }
}
