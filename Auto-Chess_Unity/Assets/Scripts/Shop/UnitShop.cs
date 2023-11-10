using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShop : MonoBehaviour
{
    [SerializeField] UIManager shopUI;
    List<Unit> unitsInShop = new List<Unit>();
    [SerializeField] UnitPool pool;
    [SerializeField] Sideline sideline;

    public void UpdateShop()
    {
        unitsInShop.Clear();
        unitsInShop = GetNewUnitsForShop();
        shopUI.UpdateUnitShop(unitsInShop);
    }

    public List<Unit> GetNewUnitsForShop()
    {
        return pool.GetRandomPool();
    }

    public void BuyUnit(GameObject go, int unitCost)
    {
        if(!go) return;

        PlayerHuman ph = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        if (ph.GetGoldCount() >= unitCost && sideline.SpaceOnBench())
        {
            ph.DecreaceGold(unitCost);
            sideline.InstanciateUnit(go);
        }
    }
}
