using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Controller : MonoBehaviour
{
    [SerializeField] float speed = 10;
    public bool playerBall = false;
    public int cdType;
    public SpriteRenderer playerRenderer;
    public Sprite BaseSprite;

    void FixedUpdate()
    {
        // Call Movement function every physics update
        Movement();
    }

    // Function to handle player movement
    void Movement()
    {
        // Vector, initially set to zero, to be modified based on player input
        Vector3 direction = Vector3.zero;

        // Check for input and modify direction vector accordingly
        if (Input.GetKey(KeyCode.RightArrow))
            direction.x += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction.x -= 1;

        // Move the player based on direction vector and speed, using physics update delta time
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
