using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 15f;
    public LayerMask groundLayer;
    private Rigidbody rb;
    private bool isGrounded;
    public float customGravity = 30f; // Custom gravity value

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);

        // Check if grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        // Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Apply custom gravity for faster falling
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * customGravity, ForceMode.Acceleration);
        }
    }
}