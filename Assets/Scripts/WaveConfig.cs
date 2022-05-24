using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Angel Wave Config")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] GameObject angelPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfAngels = 3;
    [SerializeField] float moveSpeed = 5f;

    public GameObject GetAngelPrefab() { return angelPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfAngels() { return numberOfAngels; }

    public float GetMoveSpeed() { return moveSpeed; }

}
