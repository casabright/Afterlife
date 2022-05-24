using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelSpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Use this for initialization
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllAngelsInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllAngelsInWave(WaveConfig waveConfig)
    {
        for (int angelCount = 0; angelCount < waveConfig.GetNumberOfAngels(); angelCount++)
        {
            var newAngel = Instantiate(
                waveConfig.GetAngelPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newAngel.GetComponent<AngelPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
