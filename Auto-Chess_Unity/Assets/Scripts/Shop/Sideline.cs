using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Sideline : MonoBehaviour
{
    [SerializeField] List<GameObject> sidelines = new List<GameObject>();
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
        if(sidelines.Count >= maxSidelineSize) return false;

        return true;
    }

    public GameObject GetUnitLastPressed()
    {
        //remove unit from list
        return unitLastPressed;
    }

    public void InstanciateUnit(GameObject unit)
    {
        GameObject go = Instantiate(unit);
        go.GetComponent<Unit>().SetDead();
        sidelines.Add(go);

        //create a representation in sideline
    }

    public void PutUnitOnBench(GameObject unit)
    {
        sidelines.Add(unit);
    }
}
