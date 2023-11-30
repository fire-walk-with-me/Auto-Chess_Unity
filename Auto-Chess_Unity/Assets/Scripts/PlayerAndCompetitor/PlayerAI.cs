using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    [SerializeField] List<GameObject> startPoints = new List<GameObject>();
    [SerializeField] UnitPool unitPool;
    List<Vector3> activeStartPoints = new List<Vector3>();
    int spawnAmount;

    private Vector3 FindStartPoint()
    {
        return startPoints[Random.Range(0, startPoints.Count)].transform.position;
    }

    private GameObject ChooseUnitsToSpawn()
    {
        return unitPool.GetRandomUnit();
    }

    public void SpawnCompetitorUits()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject go = ChooseUnitsToSpawn();
            Vector3 startPos = FindStartPoint();

            if (activeStartPoints.Count >= startPoints.Count) return;

            while (activeStartPoints.Contains(startPos))
            {
                startPos = FindStartPoint();
            }

            activeStartPoints.Add(startPos);

            startPos.y = 1;
            Instantiate(go, startPos, Quaternion.Euler(0, 0, 0));
            activeCharacters.Add(go);
        }

        activeStartPoints.Clear();
    }

    public void SetSpawnAmount(int amount)
    {
        spawnAmount = amount;
    }
}
