using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    [SerializeField] List<Unit> eachUniqueUnit;

    public Unit GetRandomUnit()
    {
        return eachUniqueUnit[Random.Range(0, eachUniqueUnit.Count)];
    }
}
