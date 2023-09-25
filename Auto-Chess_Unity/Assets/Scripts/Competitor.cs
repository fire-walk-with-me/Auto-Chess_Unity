using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competitor : MonoBehaviour
{
    [SerializeField] List<GameObject> ActiveCharacters;

    public int getActiveCharacterAmount()
    {
        return ActiveCharacters.Count;
    }

    public List<GameObject> getEnemyCharacters()
    {
        return ActiveCharacters;
    }
}
