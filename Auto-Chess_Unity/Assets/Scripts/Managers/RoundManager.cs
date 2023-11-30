using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] PlayerHuman playerHuman;
    [SerializeField] PlayerAI competitor;
    [SerializeField] GameManager gameManager;

    [SerializeField] int round;
    [SerializeField] float timer;
    [SerializeField] float maxTimer = 10;
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

    private IEnumerator Round()
    {
        shop.UpdateShop();
        timer = 10; //set to 30
        timerText.color = Color.blue;
        yield return new WaitForSeconds(timer);
        
        SpawnEnemyUnits();
        yield return new WaitForEndOfFrame();
        SetCharactersOnBoardActive();

        sideline.SetSidelineInactive();
        timer = maxTimer;
        timerText.color = Color.red;
        activeRound = true;

        yield return new WaitForSeconds(timer);

        activeRound = false;
        

        CheckWinner();
        ResetBoard();
        round++;
        //yield return new WaitForSeconds(1);

        StartCoroutine(Round());
    }

    private void CheckWinner()
    {
        //if one both teams still alive, check who has most champs left or something

        //if(winner) giveExtragold

        GiveGold();
    }

    private void SetCharactersOnBoardActive()
    {
        competitor.SetCharacterOnBoardActive();
        playerHuman.SetCharacterOnBoardActive();
    }

    private void SpawnEnemyUnits()
    {
        competitor.SetSpawnAmount(playerHuman.GetActiveCharacterAmount() - competitor.GetActiveCharacterAmount());
        competitor.SpawnCompetitorUits();
    }

    private void ResetBoard()
    {
        //turn all champs alive and move them to startPos
        playerHuman.ResetCharacters();
        competitor.ResetCharacters();
    }
}
