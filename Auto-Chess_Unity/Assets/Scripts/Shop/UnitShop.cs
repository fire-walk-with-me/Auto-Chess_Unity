using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitShop : MonoBehaviour
{
    [SerializeField] UIManager shopUI;
    List<Unit> unitsInShop = new List<Unit>();
    UnitPool pool;


    void Start()
    {
        pool = GetComponent<UnitPool>();
    }

    public void UpdateShop()
    {
        unitsInShop.Clear();
        unitsInShop = GetNewUnitsForShop();
        shopUI.UpdateUnitShop(unitsInShop);
    }

    public List<Unit> GetNewUnitsForShop()
    {
        return null;
    }
}
