using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script holds information about the human player

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
}
