
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text infoBarText;
    [SerializeField] TMP_Text currencyText;

    [SerializeField] List<Button> buttonList = new List<Button>();
    List<Unit> unitsInStoreList = new List<Unit>();

    private void Start()
    {
        UpdateCurrencyText();
        UpdateInfoText("Character info will be displayed here");
    }

    public void UpdateCurrencyText()
    {
        int currency = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>().GetGoldCount();
        currencyText.text = "Gold " + currency.ToString();
    }

    public void UpdateInfoText(string info)
    {
        infoBarText.text = info;
    }

    public void UpdateUnitShop(List<Unit> NewUnitsToDisplay)
    {
        unitsInStoreList.Clear();
        unitsInStoreList = NewUnitsToDisplay;

        for (int i = 0; i < buttonList.Count; ++i)
        {
            buttonList[i].GetComponentInChildren<Text>().text = unitsInStoreList[i].UnitName();
        }
    }
}
