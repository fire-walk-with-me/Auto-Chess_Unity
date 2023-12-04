using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundManager : MonoBehaviour
{
    [SerializeField] PlayerHuman playerHuman;
    [SerializeField] PlayerAI playerComputer;

    [SerializeField] int round;
    [SerializeField] float timer;
    const float AttackTime = 30;
    const float PlanTime = 15;
    [SerializeField] TMP_Text timerText;
    [SerializeField] UIManager uiManager;
    [SerializeField] UnitShop shop;
    [SerializeField] Sideline sideline;

    private bool activeRound;
    private bool computerTeamDead;
    private bool playerTeamDead;

    void Start()
    {
        round = 0;

        StartCoroutine(Round());
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0");

        if (activeRound) CheckBoardStatus();

        if(activeRound && timer <= 0) EndOfRound();
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
    }

    private void EndOfRound()
    {
        activeRound = false;

        CheckWinner();
        ResetBoard();
        round++;

        StartCoroutine(Round());
    }

    private void CheckBoardStatus()
    {
        computerTeamDead = true;

        foreach (GameObject go in playerComputer.GetActiveCharacters())
        {
            if (!go.GetComponent<Unit>().IsDead()) computerTeamDead = false;
        }

        playerTeamDead = true;

        foreach (GameObject go in playerHuman.GetActiveCharacters())
        {
            if (!go.GetComponent<Unit>().IsDead()) playerTeamDead = false;
        }

        if (computerTeamDead || playerTeamDead)
        {
            if (timer > 5) timer = 5;
        }
    }

    private void CheckWinner()
    {
        // If playerr team wins, get extra gold

        if (computerTeamDead) GiveGold();
        GiveGold();
    }

    private void SetCharactersOnBoardActive()
    {
        playerComputer.SetCharacterOnBoardActive();
        playerHuman.SetCharacterOnBoardActive();
    }

    private void SpawnEnemyUnits()
    {
        //Spawn random units for the competitor team. Will match the amount of active units that the player team has.
        int spawnAmount;

        if (playerHuman.GetActiveCharacterAmount() - playerComputer.GetActiveCharacterAmount() < 1) spawnAmount = 1;
        else spawnAmount = playerHuman.GetActiveCharacterAmount() - playerComputer.GetActiveCharacterAmount();
        playerComputer.SetSpawnAmount(spawnAmount);
        playerComputer.SpawnCompetitorUits();
    }

    private void ResetBoard()
    {
        //turn all champs alive and move them to startPos
        playerHuman.ResetCharacters();
        playerComputer.ResetCharacters();
    }
}
