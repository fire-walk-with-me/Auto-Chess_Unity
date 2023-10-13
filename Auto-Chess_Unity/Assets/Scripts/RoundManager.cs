using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] PlayerHuman playerHuman;
    [SerializeField] PlayerAI competitor;
    [SerializeField] GameManager gameManager;

    [SerializeField] int round;
    [SerializeField] float Timer;

    private bool activeRound;

    void Start()
    {
        playerHuman = GetComponent<PlayerHuman>();
        competitor = GetComponent<PlayerAI>();
        gameManager = GetComponent<GameManager>();
    }
    
    void Update()
    {
        
    }

    private void GiveGold()
    {
        int gold = 2;

        //add bonuses or interest

        playerHuman.IncreaseGold(gold);
    }

    public bool ActiveRound() => activeRound;
}
