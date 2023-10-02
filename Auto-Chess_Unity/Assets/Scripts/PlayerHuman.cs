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

    public int GetGoldCount()
    {
        return currency;
    }
}
