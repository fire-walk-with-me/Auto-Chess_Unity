using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    Unit unitOnButton;
    GameObject unit;
    UIManager manager;
    UnitShop unitShop;
    bool sold;

    private void Start()
    {
        manager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
        unitShop = FindObjectOfType<UnitShop>().GetComponent<UnitShop>();
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
        if (sold) return;

        if (unitShop.BuyUnit(unit, 2))
        {
            gameObject.GetComponentInChildren<TMP_Text>().text = "SOLD";
            sold = true;
        }
    }

    public void UpdateUnitOnButton(GameObject UnitGO)
    {
        unit = UnitGO;
        unitOnButton = unit.GetComponent<Unit>();
    }

    public void SetSold(bool s)
    {
        sold = s;
    }
}
