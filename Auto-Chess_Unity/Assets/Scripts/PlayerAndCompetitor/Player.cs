using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an abstract scripts that holds inforamtion that both the human player and the computer player utilizes.

public abstract class Player : MonoBehaviour
{
    [SerializeField] int characterLimit;
    [SerializeField] float health;
    [SerializeField] List<GameObject> ActiveCharacters;

    public int getActiveCharacterAmount()
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
            unit.Ai().SetUnitIdle();
        }
    }
}
