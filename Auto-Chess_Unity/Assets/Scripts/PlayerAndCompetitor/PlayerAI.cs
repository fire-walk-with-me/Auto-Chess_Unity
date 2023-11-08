using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerAI : Player
{
    List<PlacementNode> startPoints = new List<PlacementNode>();
    List<GameObject> unitsToSpawn = new List<GameObject>();

    void FindStartPoints()
    {

    }

    void ChooseUnitsToSpawn()
    {

    }

    public void SpawnCompetitorUits()
    {
        FindStartPoints();
        ChooseUnitsToSpawn();

        for (int i = 0; i < unitsToSpawn.Count; i++)
        {
            //Instantiate(unitsToSpawn[i], startPoints[i].position);
        }
    }
}
