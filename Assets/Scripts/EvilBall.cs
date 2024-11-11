using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBall : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f; // Speed of the enemy ball
    private Vector3 randomDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity for the enemy ball
        SetRandomDirection();
    }

    void Update()
    {
        rb.velocity = randomDirection * speed; // Move in the set direction
    }

    // Set a random direction for the ball to move in
    void SetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        randomDirection = new Vector3(randomX, randomY, 0).normalized; // 2D movement in 3D space (X and Y axes)
    }

    // Detect when the ball hits a wall, floor, or ceiling and bounce off
    void OnCollisionEnter(Collision collision)
    {
        // If the enemy ball hits a wall or ground, reflect its velocity
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Evil Ball")
        {
            randomDirection = Vector3.Reflect(randomDirection, collision.contacts[0].normal);
        }
        // If the enemy ball hits the player's ball
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject); // Kill the player's ball
        }
    }
}
