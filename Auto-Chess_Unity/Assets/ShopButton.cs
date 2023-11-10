using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    Unit unitOnButton;
    GameObject unit; 
    UIManager manager;

    private void Start()
    {
        manager = FindObjectOfType < UIManager>().GetComponent<UIManager>();
    }

    private void OnMouseEnter()
    {
        string s = unitOnButton.UnitName() + "<br>Health: " + unitOnButton.Stats().GetStat("MaxHealth") + "<br>Attack: " + unitOnButton.Stats().GetStat("Attack");
        manager.UpdateInfoText(s);
    }
    private void OnMouseExit()
    {
        manager.UpdateInfoText("Information");
    }

    public void PressButton()
    {
        manager.BuyUnit(unit, 2);
        unit = null;
        unitOnButton = null;
        manager.upd
    }

    public void UpdateUnitOnButton(Unit unit)
    {
        unitOnButton = unit;
    }
}
