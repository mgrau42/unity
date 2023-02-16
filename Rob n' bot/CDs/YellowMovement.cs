using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMovement : MonoBehaviour
{
    [SerializeField] float cdCooldown = 5;  // Cooldown time for CD movement
    [Space]
    [SerializeField] float speed = 10;  // Speed of movement
    float timeCounter = 0;  // Time counter for CD movement cooldown

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        if (timeCounter < cdCooldown)
            timeCounter += Time.deltaTime;  // Increase time counter
        if (timeCounter >= cdCooldown)  // If cooldown time is over
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("YellowCD");  // Find all CD objects with YellowCD tag
            for(int i=0;i<obj.Length;i++){
                moveCds(obj[i]);  // Move each CD object
            }
            timeCounter = 0;  // Reset time counter
        }
    }

    // Move CD object downwards
    void moveCds(GameObject obj)
    {
        Vector3 direction = Vector3.zero;
        Vector3 initialPos = obj.transform.position;

        while ((initialPos.y - obj.transform.position.y) <= 0.71f)  // Until CD object reaches the target distance
        {
            direction.y -= 1;  // Set movement direction downwards
            obj.transform.position += direction.normalized * speed * Time.deltaTime;  // Move CD object
        }
    }
}
