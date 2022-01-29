using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    public bool waitToggle = false;

    private int waypointIndex = 0;

    public float waitTime = 1f; // in seconds
    private float waitCounter = 0f;
    private bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter < waitTime)
                return;
            waiting = false;
        }

        Transform wp = waypoints[waypointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            if (waitToggle == true)
            {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;
            }

            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                wp.position,
                speed * Time.deltaTime);
        }
    }
}
