using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EnemyController))]
public class EnemyMove : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    //private int wavePointIndex = 0;
    public float startSpeed = 10f;

    private bool slow = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        //Set speed
        agent.speed = startSpeed;
        
        //Set agent destination
        target = End.instance;
        agent.destination = target.position;
    }
    
    private void Update()
    {
        //End reached
        if ((target.position - transform.position).magnitude <= 1f)
        {
            EndPath();
            return;
        }

        //enemy slowed down
        if (slow)
        {
            agent.speed = startSpeed * (1 - .5f);
            slow = false;
        }
        else
            agent.speed = startSpeed;
    }

    /*private void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.Waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = WayPoints.Waypoints[wavePointIndex];
    }*/
    
    void EndPath()
    {
        WaveSpawner.Alive--;
        PlayerStats.Hp--;
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        slow = true;
    }
}
