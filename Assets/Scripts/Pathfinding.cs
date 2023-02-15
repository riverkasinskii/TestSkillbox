using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private Spawner spawner;
    private WaveConfigSO waveConfig;
    private List<Transform> wayPoints;
    private int wayPointIndex = 0;

    private void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        waveConfig = spawner.GetCurrentWave();
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wayPointIndex < wayPoints.Count) 
        { 
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
    }
}
