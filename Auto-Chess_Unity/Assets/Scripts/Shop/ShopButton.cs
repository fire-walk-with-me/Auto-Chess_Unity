using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        unitOnButton.Stats().RandomizeStats();
        manager.UpdateInfoText(unitOnButton.Stats().GetStat("Attack").ToString(), unitOnButton.Stats().GetStat("AttackDistance").ToString(), unitOnButton.Stats().GetStat("maxHealth").ToString(), unitOnButton.Stats().GetStat("Defence").ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        manager.UpdateInfoText("", "", "", "");
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
