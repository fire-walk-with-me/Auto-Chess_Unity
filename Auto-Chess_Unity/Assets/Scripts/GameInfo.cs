using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// This is a singleton-script with static information accessable from anywhere
/// write "GameInfo.Info." and one of the functions below.
///e.g GameInfo.Info.GetRoundTimer();
///Feel free to add more Get-functions if anything you need is missing
/// </summary>
public class GameInfo : MonoBehaviour
{
    public static GameInfo Info;

    [SerializeField] RoundManager roundManager;
    [SerializeField] PlayerHuman human;
    [SerializeField] PlayerAI ai;
    [SerializeField] Sideline sideline;

    private void Awake()
    {
        Info = GetComponent<GameInfo>();
    }

    public RoundManager GetRoundManager() => roundManager;
    public float GetRoundTimer() => roundManager.Timer();
    public bool GetIsRoundActive() => roundManager.ActiveRound();
    public PlayerHuman GetHuman() => human;
    public int GetGoldCount() => human.GetGoldCount();
    public int GetHumanActiveCharacterAmount() => human.GetActiveCharacterAmount();
    public List<GameObject> GetHumanActiveCharacterList() => human.GetCharacters();
    public PlayerAI GetAI() => ai;
    public int GetAIActiveCharacterAmount() => ai.GetActiveCharacterAmount();
    public List<GameObject> GetAIActiveCharacterList() => ai.GetCharacters();
    public Sideline GetSideline() => sideline;
    public bool GetIfSpaceOnSideline() => sideline.SpaceOnBench();
    public List<GameObject> GetCharactersOnSideline() => sideline.Sidelines();

}
