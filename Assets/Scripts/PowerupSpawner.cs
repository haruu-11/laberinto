using UnityEngine;
using System.Collections.Generic;

public class PowerupSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject timePowerupPrefab;
    public GameObject speedPowerupPrefab;

    public int timePowerupCount = 3;
    public int speedPowerupCount = 2;

    private List<int> usedIndexes =
        new List<int>();

    void Start()
    {
        SpawnPowerups(timePowerupPrefab, timePowerupCount);
        SpawnPowerups(speedPowerupPrefab, speedPowerupCount);
    }

    void SpawnPowerups(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (usedIndexes.Count >= spawnPoints.Length)
                return;

            int randomIndex;

            do
            {
                randomIndex =
                    Random.Range(0, spawnPoints.Length);
            }
            while (usedIndexes.Contains(randomIndex));

            usedIndexes.Add(randomIndex);

            Instantiate(
                prefab,
                spawnPoints[randomIndex].position,
                Quaternion.identity
            );
        }
    }
}