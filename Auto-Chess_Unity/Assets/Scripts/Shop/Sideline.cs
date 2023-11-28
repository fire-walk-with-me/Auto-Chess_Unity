using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Sideline : MonoBehaviour
{
    [SerializeField] List<GameObject> sidelines = new List<GameObject>();
    [SerializeField] List<GameObject> spawnpoints = new List<GameObject>();
    PlayerHuman player;
    UIManager uiManager;
    const int maxSidelineSize = 6;
    GameObject unitLastPressed;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        uiManager = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }

    public bool SpaceOnBench()
    {
        if (sidelines.Count >= maxSidelineSize) return false;

        return true;
    }

    public void SetSidelineInactive()
    {
        foreach (GameObject unit in sidelines)
        {
            unit.GetComponent<Unit>().SetInactive();
        }
    }

    public GameObject GetUnitLastPressed()
    {
        return unitLastPressed;

        //remove unit from list
    }

    public void InstanciateUnit(GameObject unit)
    {
        Instantiate(unit);
        unit.gameObject.transform.position = spawnpoints[sidelines.Count].transform.position;
        unit.GetComponent<Unit>().SetInactive();
        sidelines.Add(unit);
    }

    public void PutUnitOnBench(GameObject unit)
    {
        sidelines.Add(unit);
    }
}
