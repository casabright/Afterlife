using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] int cloudComplexity = 5;
    [SerializeField] int cloudDiffusion = 4;
    [SerializeField] float cloudSpeed = 1f;
    [SerializeField] float timeBetweenSpawns = 10f;
    [SerializeField] int initSpawns = 6;
    [SerializeField] Sprite[] cloudSprites;
    [SerializeField] float spawnDistance = 4f;
    [SerializeField] bool looping = true;

    float spawnX;
    float initXleft;
    float initXright;
    float spawnYBottom;
    float spawnYTop;

    IEnumerator Start()
    {
        Camera gameCamera = Camera.main;
        initXleft = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        initXright = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        spawnYBottom = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        spawnYTop = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        for (int initSpawn = 0; initSpawn < initSpawns; initSpawn++)
        {
            SpawnCloud(Random.Range(initXleft, initXright));
        }

        spawnX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + spawnDistance;

        do
        {
            SpawnCloud(spawnX);
            yield return new WaitForSecondsRealtime(timeBetweenSpawns);
        }
        while (looping);
    }

    private void Update()
    {
        
    }

    public void SpawnCloud(float spawnX)
    {
        GameObject cloudObject = new GameObject("Cloud");
        int layerClouds = LayerMask.NameToLayer("Clouds");
        cloudObject.layer = layerClouds;
        Rigidbody2D cloudRigidbody2D = cloudObject.AddComponent<Rigidbody2D>();
        cloudObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        for (int cloudBuilder = 0; cloudBuilder < cloudComplexity; cloudBuilder++)
        {
            GameObject cloudSection = new GameObject("Cloud Section " + cloudBuilder);
            SpriteRenderer renderer = cloudSection.AddComponent<SpriteRenderer>();
            renderer.sprite = cloudSprites[Random.Range(0, cloudSprites.Length)];
            cloudSection.transform.SetParent(cloudObject.transform);
            cloudSection.transform.position = new Vector3(Random.Range(0, cloudDiffusion), Random.Range(0, cloudDiffusion), 5);
        }
        cloudObject.transform.position = new Vector3(spawnX, Random.Range(spawnYBottom, spawnYTop), 0);
        cloudObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-cloudSpeed, 0);
    }
}
