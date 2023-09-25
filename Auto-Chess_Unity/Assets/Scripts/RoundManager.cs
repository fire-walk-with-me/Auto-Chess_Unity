using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    Player player;
    Competitor competitor;
    GameManager gameManager;

    int round;
    float Timer;

    void Start()
    {
        player = GetComponent<Player>();
        competitor = GetComponent<Competitor>();
        gameManager = GetComponent<GameManager>();
    }

    
    void Update()
    {
        
    }

    private void GiveGold()
    {
        int gold = 2;

        //add bonuses or interest

        player.IncreaseGold(gold);
    }
}
