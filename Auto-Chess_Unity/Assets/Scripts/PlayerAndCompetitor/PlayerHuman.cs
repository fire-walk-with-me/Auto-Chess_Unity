using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : Player
{
    [SerializeField] int currency = 10;

    public void IncreaseGold(int gold)
    {
        currency += gold;
        GameInfo.Info.GetUIManager().UpdateCurrencyText();
    }

    public void DecreaceGold(int gold)
    {
        currency -= gold;
        GameInfo.Info.GetUIManager().UpdateCurrencyText();
    }

    public int GetGoldCount()
    {
        return currency;
    }
}
