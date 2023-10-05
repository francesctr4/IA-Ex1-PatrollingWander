using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // This script was used to film the video of the patrolling

    // Camera position parameters
    public Transform[] waypoints; // Array of waypoint positions
    public float teleportInterval; // Time interval between teleports in seconds

    private int currentWaypoint = 0;
    private float lastTeleportTime = 0.0f;

    private void Start()
    {
        SetWaypoints();
        TeleportToWaypoint(currentWaypoint);
    }

    private void SetWaypoints()
    {
        if (waypoints.Length < 2)
        {
            Debug.LogError("You need at least 2 waypoints for camera teleportation.");
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        if (Time.time - lastTeleportTime >= teleportInterval)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                // Uncomment to loop the camera positions
                //currentWaypoint = 0; // Wrap around to the first waypoint
            }

            TeleportToWaypoint(currentWaypoint);
            lastTeleportTime = Time.time;
        }
    }

    private void TeleportToWaypoint(int waypointIndex)
    {
        // Change the position and the rotation of the camera to the next waypoint
        transform.position = waypoints[waypointIndex].position;
        transform.rotation = waypoints[waypointIndex].rotation;
    }

}
