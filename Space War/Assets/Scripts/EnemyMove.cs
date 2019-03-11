using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    WaveConfig waveConfig;
    List<Transform> waypoints;

    int waypoints_index=0;

    bool Alive = true;
    Health health;
	// Use this for initialization
	void Start () {
        health = GetComponent<Health>();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypoints_index].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        checkAlive();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypoints_index <= waypoints.Count - 1)
        {
            if (Alive)
            {
                var targetPosition = waypoints[waypoints_index].transform.position;
                var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

                if (transform.position == targetPosition)
                {
                    waypoints_index++;
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void checkAlive()
    {
        Alive = health.getAlive();
    }
}
