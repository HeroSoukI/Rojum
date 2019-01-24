using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private bool isGrounded = false;
    public int moveSpeed;
    Rigidbody2D rb;
    public float distanceFloor = 0.5f;
    Vector3 vel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (isGrounded == true)
        {
            vel.x = moveSpeed;
            rb.velocity = vel;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isGrounded = false;
    }
}
    

