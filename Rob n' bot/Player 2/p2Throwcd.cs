using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Throwcd : MonoBehaviour
{
    public p2Controller p2con; // Reference to the p2Controller script.
    public SpriteRenderer playerRenderer; // Reference to the SpriteRenderer component.
    public Sprite defaultSprite; // The default sprite for the player.
    public GameObject Prefab1; // The prefab for the blue CD.
    public GameObject Prefab2; // The prefab for the green CD.
    public GameObject Prefab3; // The prefab for the yellow CD.
    public GameObject Prefab4; // The prefab for the red CD.

    void FixedUpdate()
    {
        ThrowCd();
    }

    // Throws the CD if the player has it and presses the up arrow key.
    void ThrowCd()
    {
        LayerMask mask1 = LayerMask.GetMask("CDs"); // The layer mask to detect the CDs.
        float distance = 200; // The maximum distance to detect CDs.

        if (Input.GetKeyDown(KeyCode.UpArrow) && ((p2con.playerBall))) // If the player presses the up arrow key and has the CD.
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), distance); // Raycast to detect the CD.

            if (hit.collider != null) // If the raycast hit something.
            {
                cdreturner(hit); // Return the CD to its position.
            }
        }
    }

    // Returns the CD to its original position and creates a new CD prefab.
    void cdreturner(RaycastHit2D hit)
    {
        Vector3 CDposition = hit.collider.transform.position; // Get the position of the CD.
        CDposition.y -= 0.71f; // Move the position down to the correct position.

        // Create a new CD prefab depending on the type of CD the player has.
        if (p2con.cdType == 1)
        {
            Instantiate(Prefab1, CDposition, transform.rotation);
        }
        else if (p2con.cdType == 2)
        {
            Instantiate(Prefab2, CDposition, transform.rotation);
        }
        else if (p2con.cdType == 3)
        {
            Instantiate(Prefab3, CDposition, transform.rotation);
        }
        else if (p2con.cdType == 4)
        {
            Instantiate(Prefab4, CDposition, transform.rotation);
        }

        p2con.cdType = 0; // Reset the CD type.
        p2con.playerBall = false; // The player doesn't have the CD anymore.
        playerRenderer.sprite = defaultSprite; // Set the player's sprite to the default sprite.
    }
}
