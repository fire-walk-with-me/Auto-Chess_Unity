
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text currencyText;
    [SerializeField] TMP_Text infoBarAttackText;
    [SerializeField] TMP_Text infoBarAttackDisText;
    [SerializeField] TMP_Text infoBarHealthText;
    [SerializeField] TMP_Text infoBarDefenceText;

    Sideline sideline;
    PlayerHuman player;

    [SerializeField] List<Button> buttonList = new List<Button>();
    List<GameObject> unitsInStoreList = new List<GameObject>();

    private void Start()
    {
        player = FindObjectOfType<PlayerHuman>().GetComponent<PlayerHuman>();
        sideline = FindObjectOfType<Sideline>().GetComponent<Sideline>();
        UpdateCurrencyText();
        UpdateInfoText("", "", "", "");
    }

    public void UpdateCurrencyText()
    {
        int currency = player.GetGoldCount();
        currencyText.text = "Gold " + currency.ToString();
    }

    public void UpdateInfoText(string attack, string attackDis, string helath, string defence)
    {
        infoBarAttackText.text = "Attack: " + attack;
        infoBarAttackDisText.text = "Attack Dist: " + attackDis;
        infoBarHealthText.text = "Health: " + helath;
        infoBarDefenceText.text = "Defence: " + defence;
    }

    public void UpdateUnitShop(List<GameObject> NewUnitsToDisplay)
    {
        //unitsInStoreList.Clear();
        unitsInStoreList = NewUnitsToDisplay;

        for (int i = 0; i < buttonList.Count; ++i)
        {
            buttonList[i].GetComponentInChildren<TMP_Text>().text = unitsInStoreList[i].GetComponent<Unit>().UnitName();
            buttonList[i].gameObject.GetComponent<ShopButton>().UpdateUnitOnButton(unitsInStoreList[i]);
            buttonList[i].gameObject.GetComponent<ShopButton>().SetSold(false);
            buttonList[i].gameObject.GetComponent<StatRandomizer>().RandomizeStats();
        }
    }
}
