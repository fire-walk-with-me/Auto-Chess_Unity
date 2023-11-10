using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : Player
{
    [SerializeField] int currency;

    public void IncreaseGold(int gold)
    {
        currency += gold;
    }

    public void DecreaceGold(int gold)
    {
        currency -= gold;
    }

    public int GetGoldCount()
    {
        return currency;
    }

    public void AddToActiveUnits(GameObject unit)
    {
        ActiveCharacters.Add(unit);
    }

    public void RemoveFromActiveUnits(GameObject unit)
    {
        ActiveCharacters.Remove(unit);
    }
}
