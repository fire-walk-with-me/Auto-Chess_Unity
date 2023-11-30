using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : Player
{
    [SerializeField] int currency = 10; // change before release

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
}
