using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Throwcd : MonoBehaviour
{
    // Declare public variables
    public p1Controller p1con;
    public SpriteRenderer playerRenderer;
    public Sprite defaultSprite;
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Call the ThrowCd() function every fixed frame
        ThrowCd();
    }

    void ThrowCd()
    {
        // Define a layer mask and a maximum distance for the raycast
        LayerMask mask1 = LayerMask.GetMask("CDs");
        float distance = 200;

        // Check if the player has the ball and has pressed the throw key
        if (Input.GetKeyDown(KeyCode.W) && ((p1con.playerBall)))
        {
            // Cast a ray from the player's position in the up direction
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), distance);

            // If the ray hit something, the RaycastHit2D.collider will not be null
            if (hit.collider != null)
            {
                // Call the cdreturner function with the hit object
                cdreturner(hit);
            }
        }
    }

    void cdreturner(RaycastHit2D hit)
    {
        // Get the position of the hit object and move it down slightly
        Vector3 CDposition = hit.collider.transform.position;
        CDposition.y -= 0.71f;

        // Instantiate the appropriate prefab based on the type of CD held by the player
        if (p1con.cdType == 1)
        {
            Instantiate(Prefab1, CDposition, transform.rotation);
        }
        else if (p1con.cdType == 2)
        {
            Instantiate(Prefab2, CDposition, transform.rotation);
        }
        else if (p1con.cdType == 3)
        {
            Instantiate(Prefab3, CDposition, transform.rotation);
        }
        else if (p1con.cdType == 4)
        {
            Instantiate(Prefab4, CDposition, transform.rotation);
        }

        // Reset the player's CD type and ball status, and set the player's sprite to the default
        p1con.cdType = 0;
        p1con.playerBall = false;
        playerRenderer.sprite = defaultSprite;
    }
}
