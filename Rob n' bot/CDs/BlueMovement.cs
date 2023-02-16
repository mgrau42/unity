using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMovement : MonoBehaviour
{
    // Cooldown time for the movement of Blue CDs
    [SerializeField] float cdCooldown = 5;
    // Space in the Inspector for better organization
    [Space]
    // Speed of Blue CDs movement
    [SerializeField] float speed = 10;
    // Counter for the time elapsed since last Blue CDs movement
    float timeCounter = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Increment the time counter for elapsed time
        if (timeCounter < cdCooldown)
            timeCounter += Time.deltaTime;

        // Check if cooldown time has elapsed
        if (timeCounter >= cdCooldown)
        {
            // Find all Blue CDs in the scene
            GameObject[] obj = GameObject.FindGameObjectsWithTag("BlueCD");
            // Move each Blue CD using the moveCds function
            for (int i = 0; i < obj.Length; i++)
            {
                moveCds(obj[i]);
            }
            // Reset the time counter
            timeCounter = 0;
        }
    }

    // Function to move Blue CDs
    void moveCds(GameObject obj)
    {
        // Set the initial movement direction and position of Blue CD
        Vector3 direction = Vector3.zero;
        Vector3 initialPos = obj.transform.position;

        // Keep moving the Blue CD until it reaches a certain point
        while ((initialPos.y - obj.transform.position.y) <= 0.71f)
        {
            // Move the Blue CD downwards
            direction.y -= 1;
            obj.transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}
