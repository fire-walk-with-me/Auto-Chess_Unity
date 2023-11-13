using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShop : MonoBehaviour
{
    [SerializeField] UIManager shopUI;
    List<GameObject> unitsInShop = new List<GameObject>();
    [SerializeField] UnitPool pool;
    [SerializeField] Sideline sideline;

    public void UpdateShop()
    {
        unitsInShop.Clear();
        unitsInShop = GetNewUnitsForShop();
        shopUI.UpdateUnitShop(unitsInShop);
    }

    public List<GameObject> GetNewUnitsForShop()
    {
        return pool.GetRandomPool();
    }

    public bool BuyUnit(GameObject unit, int unitCost)
    {
        if(!unit) return false;

        PlayerHuman ph = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        if (ph.GetGoldCount() >= unitCost && sideline.SpaceOnBench())
        {
            ph.DecreaceGold(unitCost);
            shopUI.UpdateCurrencyText();
            sideline.InstanciateUnit(unit);
            return true;
        }
        return false;
    }
}
