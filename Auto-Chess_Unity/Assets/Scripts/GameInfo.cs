using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// This is a singleton-script with static information accessable from anywhere
/// write "GameInfo.Info." and one of the functions below.
/// e.g GameInfo.Info.GetRoundTimer();
/// Feel free to add more Get-functions if anything you need is missing
/// </summary>
public class GameInfo : MonoBehaviour
{
    public static GameInfo Info { get; private set; }

    [SerializeField] RoundManager roundManager;
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerHuman human;
    [SerializeField] PlayerAI ai;
    [SerializeField] Sideline sideline;
    

    private void Awake()
    {
        //If there is more than one instance of the singelton, and the instance is not this, destroy this
        if (Info != null && Info != this)
        {
            Destroy(this);
        }
        else
        {
            Info = this;
        }
    }

    public RoundManager GetRoundManager() => roundManager;
    public float GetRoundTimer() => roundManager.Timer();
    public bool GetIsRoundActive() => roundManager.ActiveRound();
    public PlayerHuman GetHuman() => human;
    public int GetGoldCount() => human.GetGoldCount();
    public int GetHumanActiveCharacterAmount() => human.GetActiveCharacterAmount();
    public List<GameObject> GetHumanActiveCharacterList() => human.GetActiveCharacters();
    public PlayerAI GetAI() => ai;
    public int GetAIActiveCharacterAmount() => ai.GetActiveCharacterAmount();
    public List<GameObject> GetAIActiveCharacterList() => ai.GetActiveCharacters();
    public Sideline GetSideline() => sideline;
    public bool GetIfSpaceOnSideline() => sideline.SpaceOnBench();
    public List<GameObject> GetCharactersOnSideline() => sideline.Sidelines();
    public UIManager GetUIManager() => uiManager;

}
