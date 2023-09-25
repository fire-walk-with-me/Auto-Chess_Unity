using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script holds logic for over-seeing the game. It commuicates with roundManager and player scripts

public class GameManager : MonoBehaviour
{
    RoundManager roundManager;
    Player player;

    private void Awake()
    {
        roundManager = GetComponent<RoundManager>();
        player = GetComponent<Player>();
    }
}
