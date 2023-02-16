using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Holdcd : MonoBehaviour
{
    // Referencing the p2Controller script
    public p2Controller p2con;
    // Reference to the player sprite renderer
    public SpriteRenderer playerRenderer;
    // Sprites for the CDs that the player can hold
    public Sprite holdBSprite;
    public Sprite holdRSprite;
    public Sprite holdYSprite;
    public Sprite holdGSprite;

    void FixedUpdate()
    {
        // Call the "obtener" function in every FixedUpdate frame
        obtener();
    }

    /* This function handles CD collection and detection */
    void obtener()
    {
        // Define a new layer mask
        LayerMask mask1 = LayerMask.GetMask("CDs");
        // Define the raycast distance
        float distance = 200;

        // Check if the "DownArrow" key is pressed and the player is not currently holding a CD
        if (Input.GetKeyDown(KeyCode.DownArrow) && (!p2con.playerBall))
        {
            // Cast a ray from the player's position, pointing up, for a certain distance and get the hit collider
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), distance, mask1);

            // Check if the ray hit anything
            if (hit.collider != null)
            {
                // Call the "cdDetection" function with the hit collider as a parameter
                cdDetection(hit);
                // Destroy the hit object
                Destroy(hit.transform.gameObject);
            }
        }
        // Check if the "DownArrow" key is pressed and the player is currently holding a CD
        else if (Input.GetKeyDown(KeyCode.DownArrow) && (p2con.playerBall))
        {
            // TODO: Add shake animation
        }
    }

    /* This function detects which CD the player collected and sets the necessary variables */
    void cdDetection(RaycastHit2D hit)
    {
        if (hit.collider.tag == "BlueCD")
        {
            // Set the player's CD type to 1 (blue)
            p2con.cdType = 1;
            // Set the player's "playerBall" variable to true (holding a CD)
            p2con.playerBall = true;
            // Set the player sprite to the blue CD sprite
            playerRenderer.sprite = holdBSprite;
        }
        else if (hit.collider.tag == "GreenCD")
        {
            // Set the player's CD type to 2 (green)
            p2con.cdType = 2;
            // Set the player's "playerBall" variable to true (holding a CD)
            p2con.playerBall = true;
            // Set the player sprite to the green CD sprite
            playerRenderer.sprite = holdGSprite;
        }
        else if (hit.collider.tag == "YellowCD")
        {
            // Set the player's CD type to 3 (yellow)
            p2con.cdType = 3;
            // Set the player's "playerBall" variable to true (holding a CD)
            p2con.playerBall = true;
            // Set the player sprite to the yellow CD sprite
            playerRenderer.sprite = holdYSprite;
        }
        else if (hit.collider.tag == "RedCD")
        {
            // Set the player's CD type to 4 (red)
            p2con.cdType = 4;
            // Set the player's "playerBall" variable to true (holding a CD)
            p2con.playerBall = true;
            // Set the player sprite to the red CD sprite
            playerRenderer.sprite = holdRSprite;
        }
    }
}
