using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    private Rigidbody2D rb;
    private float movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = 0;

        if (Input.GetKey(KeyCode.W))   
            movement = 1;

        if (Input.GetKey(KeyCode.A))    
            movement = -1;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, movement * moveSpeed);
    }
}