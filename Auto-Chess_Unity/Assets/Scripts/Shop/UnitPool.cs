using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    [SerializeField] List<GameObject> eachUniqueUnit;
    List<GameObject> randomPick = new List<GameObject>();
    string playerTag = "Player";
    string competitorTag = "Competitor";
    public GameObject GetRandomUnit()
    {
        GameObject unit = eachUniqueUnit[Random.Range(0, eachUniqueUnit.Count)];
        unit.tag = competitorTag;
        return unit;
    }

    public List<GameObject> GetRandomPool()
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
