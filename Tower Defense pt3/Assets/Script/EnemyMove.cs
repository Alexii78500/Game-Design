using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMove : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;
    public float startSpeed = 10f;
    private float speed;

    private void Start()
    {
        target = WayPoints.Waypoints[0];
        speed = startSpeed;
    }
    
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWayPoint();
        }

        speed = startSpeed;
    }

    private void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.Waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = WayPoints.Waypoints[wavePointIndex];
    }
    
    void EndPath()
    {
        WaveSpawner.Alive--;
        PlayerStats.Hp--;
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1 - pct);
    }
}
