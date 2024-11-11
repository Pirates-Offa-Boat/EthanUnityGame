using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
   public float life;
    public float speed;
    private Waypoints Wpoints;
    private int waypointIndex;

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);
        // Use Vector3.MoveTowards to move along the x, y, and z axes.

        // Check if the enemy has reached the current waypoint.
        if (Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            // Increment the waypoint index to move to the next waypoint.
            waypointIndex++;
        }
      if(life <=0){

         Destroy(gameObject);

      }
   }
}