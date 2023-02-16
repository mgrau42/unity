using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMovement : MonoBehaviour
{
    [SerializeField] float cdCooldown = 5; // The cooldown time for moving the objects
    [Space]
    [SerializeField] float speed = 10; // The speed at which the objects will move
    float timeCounter = 0; // Counter for measuring the cooldown time

    // FixedUpdate is called every fixed frame-rate frame
    void FixedUpdate()
    {
        if (timeCounter < cdCooldown) // If the cooldown time has not yet passed
			timeCounter += Time.deltaTime; // Increase the counter by delta time
        if (timeCounter >= cdCooldown) // If the cooldown time has passed
		{
        GameObject[] obj = GameObject.FindGameObjectsWithTag("RedCD"); // Find all game objects with the tag "RedCD"
        for(int i=0;i<obj.Length;i++){ // For each game object
            moveCds(obj[i]); // Move the game object
        }
			timeCounter = 0; // Reset the counter
		}
    }

    // Move the given game object
    void moveCds(GameObject obj)
    {
        Vector3 direction = Vector3.zero; // The movement direction
        Vector3 initialPos = obj.transform.position; // The initial position of the game object

        while ((initialPos.y - obj.transform.position.y) <= 0.71f) // While the game object has not moved the desired distance
        {
            direction.y -= 1; // Set the direction to move downwards
            obj.transform.position += direction.normalized * speed * Time.deltaTime; // Move the game object in the desired direction
        }
    }
}
