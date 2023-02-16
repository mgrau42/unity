using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMovement : MonoBehaviour
{
    [SerializeField] float cdCooldown = 5;  // Cooldown between CD movements
    [Space]
    [SerializeField] float speed = 10;  // Speed of the CD movement
    float timeCounter = 0;  // Counter for the cooldown

    void FixedUpdate()
    {
        // Increase the time counter by the amount of time that has passed since the last frame
        if (timeCounter < cdCooldown)
			timeCounter += Time.deltaTime;

        // If the cooldown is over, move the CDs with the "GreenCD" tag
        if (timeCounter >= cdCooldown)
		{
            GameObject[] obj = GameObject.FindGameObjectsWithTag("GreenCD");
            for(int i=0;i<obj.Length;i++){
                moveCds(obj[i]);  // Call the moveCds function on each CD
            }
			timeCounter = 0;  // Reset the time counter
		}
    }

    void moveCds(GameObject obj)
    {
        Vector3 direction = Vector3.zero;  // Vector for the direction of movement
        Vector3 initialPos = obj.transform.position;  // Initial position of the CD

        // Move the CD while it has not moved the full distance of 0.71 units
        while ((initialPos.y - obj.transform.position.y) <= 0.71f)
        {
            direction.y -= 1;  // Move the CD downwards
            obj.transform.position += direction.normalized * speed * Time.deltaTime;  // Move the CD in the direction and at the speed specified
        }
    }
}
