using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    public GameObject[] powerUpPrefabs;
    public float spawnInterval = 7f;

    public float minX = -7f;
    public float maxX = 7f;
    public float minY = -3.5f;
    public float maxY = 3.5f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), spawnInterval, spawnInterval);
    }

    private void SpawnPowerUp()
    {
        if (powerUpPrefabs.Length == 0) return;

        Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        int index = Random.Range(0, powerUpPrefabs.Length);
        Instantiate(powerUpPrefabs[index], pos, Quaternion.identity);
    }
}
