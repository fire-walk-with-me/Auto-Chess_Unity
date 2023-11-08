
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text infoBarText;
    [SerializeField] TMP_Text currencyText;
    Sideline sideline;
    PlayerHuman player;

    [SerializeField] List<Button> buttonList = new List<Button>();
    List<Unit> unitsInStoreList = new List<Unit>();

    private void Start()
    {
        player = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        sideline = FindObjectOfType<Sideline>().GetComponent<Sideline>();
        UpdateCurrencyText();
        UpdateInfoText("Character info will be displayed here");
    }

    public void UpdateCurrencyText()
    {
        int currency = player.GetGoldCount();
        currencyText.text = "Gold " + currency.ToString();
    }

    public void UpdateInfoText(string info)
    {
        infoBarText.text = info;
    }

    public void UpdateUnitShop(List<Unit> NewUnitsToDisplay)
    {
        //unitsInStoreList.Clear();
        unitsInStoreList = NewUnitsToDisplay;

        for (int i = 0; i < buttonList.Count; ++i)
        {
            buttonList[i].GetComponentInChildren<TMP_Text>().text = unitsInStoreList[i].UnitName();
        }
    }

    public void BuyUnit(GameObject unit, int cost)
    {
        if (cost <= player.GetGoldCount())
        {
            sideline.InstanciateUnit(unit);
            player.DecreaceGold(cost);
            //remove unit from store
        }
    }
}