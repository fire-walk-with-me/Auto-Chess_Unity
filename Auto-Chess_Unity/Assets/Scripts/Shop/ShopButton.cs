using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Unit unitOnButton;
    GameObject unit;
    UIManager manager;
    UnitShop unitShop;
    bool sold;
    StatRandomizer statRan;

    [SerializeField] Sprite meleeSprite;
    [SerializeField] Sprite rangeSprite;
    [SerializeField] Sprite emptySprite;

    private void Start()
    {
        manager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
        unitShop = FindObjectOfType<UnitShop>().GetComponent<UnitShop>();
        statRan = gameObject.GetComponent<StatRandomizer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.UpdateInfoText(statRan.GetAttack().ToString("0"), statRan.GetAttackDistance().ToString("0"), statRan.GetMaxHealth().ToString("0"), statRan.GetDefence().ToString("0"));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        manager.UpdateInfoText("", "", "", "");
    }

    public void PressButton()
    {
        if (sold) return;

        if (unitShop.BuyUnit(unit, 2, statRan))
        {
            //gameObject.GetComponentInChildren<TMP_Text>().text = "";
            gameObject.GetComponent<Image>().sprite = emptySprite;
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

    public GameObject GetUnitOnButton()
    {
        return unit;
    }

    public void UpdatePortrateOnButton()
    {
        if (unit.gameObject.GetComponent<Range>())
        {
            gameObject.GetComponent<Image>().sprite = rangeSprite;
        }
        else if (unit.gameObject.GetComponent<Melee>())
        {
            gameObject.GetComponent<Image>().sprite = meleeSprite;
        }
    }
}
