using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed;
    public float life;
    public int damage;
    private Waypoints Wpoints;
    public int value;
    private int waypointIndex;

    void Start()
    {
      Wpoints = FindObjectOfType<LevelManager>().waypoints;
    }

    void Update()
    {
        // Rotate to face the next waypoint
        transform.LookAt(Wpoints.waypoints[waypointIndex].position);
        transform.Rotate(0 , 180, 0);
        // Use Vector3.MoveTowards to move along the x, y, and z axes.
        transform.position = Vector3.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);
        // Use Vector3.MoveTowards to move along the x, y, and z axes.

        // Check if the enemy has reached the current waypoint.
        if (Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            // Increment the waypoint index to move to the next waypoint.
            waypointIndex++;
        }

        if (waypointIndex == Wpoints.Length)
        {
            LevelManager.onEnemyDestroy.Invoke();
            LevelManager.main.DealDamage(damage);
            Destroy(gameObject);
            return;
        }

        if (life <= 0)
        {
            LevelManager.main.gold += value;
            LevelManager.onEnemyDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}