using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Sideline : MonoBehaviour
{
    [SerializeField] List<GameObject> sidelines = new List<GameObject>();
    [SerializeField] List<Button> buttonList = new List<Button>();
    PlayerHuman player;
    UIManager uiManager;
    const int maxSidelineSize = 6;
    GameObject unitLastPressed;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        uiManager = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();

        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].gameObject.SetActive(false);
        }
    }

    public bool SpaceOnBench()
    {
        if (sidelines.Count >= maxSidelineSize) return false;

        return true;
    }

    public GameObject GetUnitLastPressed()
    {
        return unitLastPressed;

        //remove unit from list
    }

    public void InstanciateUnit(GameObject unit)
    {
        Instantiate(unit);
        sidelines.Add(unit);

        for (int i = 0; i < sidelines.Count; i++)
        {
            if (buttonList[i].gameObject.activeSelf) continue;

            buttonList[i].GetComponent<SidelineButton>().SetUnitOnButton(unit);
        }

        unit.GetComponent<Unit>().SetDead();
        UpdateSidelinesButtons();
    }

    public void PutUnitOnBench(GameObject unit)
    {
        sidelines.Add(unit);
    }

    public void UpdateSidelinesButtons()
    {
        for (int i = 0; i < sidelines.Count; i++)
        {
            if (buttonList[i].gameObject.activeSelf) continue;

            buttonList[i].gameObject.SetActive(true);
            buttonList[i].GetComponent<SidelineButton>().SetName();
        }
    }
}
