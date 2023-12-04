using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an abstract scripts that holds inforamtion that both the human player and the computer player utilizes.
public abstract class Player : MonoBehaviour
{
    [SerializeField] protected int characterLimit;
    [SerializeField] protected float health;
    [SerializeField] protected List<GameObject> activeCharacters = new List<GameObject>();

    private void Start()
    {
        activeCharacters.Clear();
    }
    public int GetActiveCharacterAmount()
    {
        return activeCharacters.Count;
    }

    public List<GameObject> GetActiveCharacters()
    {
        return activeCharacters;
    }

    public void ResetCharacters()
    {
        foreach (GameObject character in activeCharacters) 
        {
            Unit unit = character.GetComponent<Unit>();

            unit.SetAlive();
            unit.ResetPoistion();
            unit.Ai().SetUnitIdle();
            unit.SetInactive();
        }
    }
    public void AddToActiveUnits(GameObject unit)
    {
        activeCharacters.Add(unit);
    }

    public void RemoveFromActiveUnits(GameObject unit)
    {
        activeCharacters.Remove(unit);
    }

    public void SetCharacterOnBoardActive()
    {
        foreach (GameObject character in activeCharacters)
        {
            Unit unit = character.GetComponent<Unit>();
            unit.GetComponent<Unit>().SetActive();
        }
    }
    public void SetCharacterOnBoardInctive()
    {
        foreach (GameObject character in activeCharacters)
        {
            Unit unit = character.GetComponent<Unit>();
            unit.GetComponent<Unit>().SetInactive();
        }
    }
}
