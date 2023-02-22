using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the rotation of the game piece. 
** It rotates the piece 90 degrees around the rotationPoint when the up arrow key is pressed. 
** It also checks if the new position of the piece is valid using the onRange() method
** from the pieceMovement script, and if not, rotates the piece back to its previous position.
*/
public class pieceRotation : MonoBehaviour
{
    public Vector3 rotationPoint; // the point around which to rotate the piece

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) // if the up arrow key is pressed
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint),Vector3.forward,90); // rotate the piece 90 degrees around the rotation point
            if(!(FindObjectOfType<pieceMovement>().onRange(0))) // check if the new position is valid using the onRange() method from pieceMovement script, if not, rotate back to previous position
                transform.RotateAround(transform.TransformPoint(rotationPoint),Vector3.forward,-90);
        }
    }
}
