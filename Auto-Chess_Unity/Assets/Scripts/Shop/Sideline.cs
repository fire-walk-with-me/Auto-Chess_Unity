using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sideline : MonoBehaviour
{
    [SerializeField] List<GameObject> sidelines = new List<GameObject>();
    PlayerHuman player;
    UIManager uiManager;
    const int maxSidelineSize = 6;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        uiManager = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }

    public void InstanciateUnit(GameObject unit)
    {
        if (sidelines.Count >= maxSidelineSize) return;

        GameObject go = Instantiate(unit);
        go.GetComponent<Unit>().SetInactive();
        sidelines.Add(go);

        //create a representation in sideline
    }
}
