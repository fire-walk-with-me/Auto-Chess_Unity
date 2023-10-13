using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    [SerializeField] List<Unit> eachUniqueUnit;
    List<Unit> randomPick = new List<Unit>();
    string playerTag = "Player";
    string competitorTag = "Competitor";
    public Unit GetRandomUnit()
    {
        Unit unit = eachUniqueUnit[Random.Range(0, eachUniqueUnit.Count)];
        unit.tag = competitorTag;
        return unit;
    }

    public List<Unit> GetRandomPool()
    {
        randomPick.Clear();

        for (int i = 0; i < 6; i++)
        {
            randomPick.Add(GetRandomUnit());
            randomPick[i].tag = playerTag;
        }

        return randomPick;
    }
}
