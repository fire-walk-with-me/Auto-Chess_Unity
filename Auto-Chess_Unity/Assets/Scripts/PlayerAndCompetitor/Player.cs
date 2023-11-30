using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an abstract scripts that holds inforamtion that both the human player and the computer player utilizes.

public abstract class Player : MonoBehaviour
{
    [SerializeField] protected int characterLimit;
    [SerializeField] protected float health;
    [SerializeField] protected List<GameObject> ActiveCharacters;

    public int GetActiveCharacterAmount()
    {
        return ActiveCharacters.Count;
    }

    public List<GameObject> GetCharacters()
    {
        return ActiveCharacters;
    }

    public void ResetCharacters()
    {
        foreach (GameObject character in ActiveCharacters) 
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
        ActiveCharacters.Add(unit);
    }

    public void RemoveFromActiveUnits(GameObject unit)
    {
        ActiveCharacters.Remove(unit);
    }

    public void SetCharacterOnBoardActive()
    {
        foreach (GameObject character in ActiveCharacters)
        {
            character.GetComponent<Unit>().SetActive();
        }
    }
    public void SetCharacterOnBoardInctive()
    {
        foreach (GameObject character in ActiveCharacters)
        {
            character.GetComponent<Unit>().SetInactive();
        }
    }
}
