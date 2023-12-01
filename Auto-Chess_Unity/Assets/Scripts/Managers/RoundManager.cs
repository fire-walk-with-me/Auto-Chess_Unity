using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundManager : MonoBehaviour
{
    [SerializeField] PlayerHuman playerHuman;
    [SerializeField] PlayerAI competitor;

    [SerializeField] int round;
    [SerializeField] float timer;
    const float AttackTime = 30;
    const float PlanTime = 15;
    [SerializeField] TMP_Text timerText;
    [SerializeField] UIManager uiManager;
    [SerializeField] UnitShop shop;
    [SerializeField] Sideline sideline;

    private bool activeRound;

    void Start()
    {
        round = 0;

        StartCoroutine(Round());
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0");
    }

    private void GiveGold()
    {
        int gold = 4;

        //add bonuses or interest

        playerHuman.IncreaseGold(gold);

        uiManager.UpdateCurrencyText();
    }

    public bool ActiveRound() => activeRound;
    public float Timer() => timer;

    private IEnumerator Round()
    {
        //The round-loop is 10s planning, and then 30s fighting

        shop.UpdateShop();
        timer = PlanTime;
        timerText.color = Color.blue;
        yield return new WaitForSeconds(timer);
        
        SpawnEnemyUnits();
        yield return new WaitForEndOfFrame();
        SetCharactersOnBoardActive();

        sideline.SetSidelineInactive();
        timer = AttackTime;
        timerText.color = Color.red;
        activeRound = true;

        yield return new WaitForSeconds(timer);

        activeRound = false;
        

        CheckWinner();
        ResetBoard();
        round++;

        StartCoroutine(Round());
    }

    private void CheckWinner()
    {
        //if one both teams still alive, check who has most champs left or something

        //if(winner) giveExtraGold

        GiveGold();
    }

    private void SetCharactersOnBoardActive()
    {
        competitor.SetCharacterOnBoardActive();
        playerHuman.SetCharacterOnBoardActive();
    }

    private void SpawnEnemyUnits()
    {
        //Spawn random units for the competitor team. Will match the amount of active units that the player team has.
        int spawnAount;

        if(playerHuman.GetActiveCharacterAmount() - competitor.GetActiveCharacterAmount() < 1) spawnAount = 1;
        else spawnAount = playerHuman.GetActiveCharacterAmount() - competitor.GetActiveCharacterAmount();
        competitor.SetSpawnAmount(spawnAount);
        competitor.SpawnCompetitorUits();
    }

    private void ResetBoard()
    {
        //turn all champs alive and move them to startPos
        playerHuman.ResetCharacters();
        competitor.ResetCharacters();
    }
}
