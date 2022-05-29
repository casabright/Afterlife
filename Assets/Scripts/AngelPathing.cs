using System.Collections.Generic;
using UnityEngine;

public class AngelPathing : MonoBehaviour
{
    GameManager gameManager;
    WaveConfig waveConfig;
    SceneLoader sceneLoader;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        // Move angel towards the next waypoint in the path then advance to the next waypoint. 
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            // Remove angel and move player up in line.
            Destroy(gameObject);
            gameManager.MoveUpInLine(Random.Range(1000, 10000));
            
            // Check if player has won
            if (gameManager.GetPlaceInLine() <= 144000)
            {
                sceneLoader.LoadHeaven();
            }

        }
    }

}
