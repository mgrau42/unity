using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killzone : MonoBehaviour
{
    // This method is called when a 2D collider enters the trigger area of the game object.
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Get the game object that collided with the trigger.
        GameObject collisionGameObject = collision.gameObject;

        // Check if the collided object is one of the CD game objects.
        if ((collisionGameObject.tag == "BlueCD") | (collisionGameObject.tag == "GreenCD") | (collisionGameObject.tag == "RedCD") | (collisionGameObject.tag == "YellowCD"))
        {
            // Quit the game application.
            Application.Quit();
        }
    }
}
