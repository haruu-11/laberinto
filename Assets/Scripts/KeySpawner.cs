using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    void Start()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        transform.position = spawnPoints[randomIndex].position;
    }
}