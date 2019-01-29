using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    
    public int moveSpeed;
    public float hitDistance;
    public LayerMask layer;
    Rigidbody2D rb;
    public bool isGrounded = false;
    Vector3 vel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
    //    updateStats();
        if(rb.velocity.y == 0){
            vel.x = moveSpeed;
            rb.velocity = vel;
        }
    }

   

    void updateStats()
    {

        if (isGrounded)
        {
            hitDistance = 0.35f;
        }
        else
            hitDistance = 0.15f;
        if (Physics2D.Raycast(transform.position = new Vector2(0, 0.9f), -transform.up, hitDistance, layer))
            isGrounded = true;
        else
            isGrounded = false;
    }
}
    

