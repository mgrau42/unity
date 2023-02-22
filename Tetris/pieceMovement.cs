using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceMovement : MonoBehaviour
{
    [SerializeField] float fallTime = 0.5f;
    float previousTime = 0;
    public static int width = 10;
    public static int height = 20;
    /*************************************************************************/
    public pieceRotation pieceRotation; // Reference to rotation script
    public GridManager gridManager; // Reference to grid management script
    public static Transform[,] grid = new Transform[width, height]; // Create the grid

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && OnRange(-1))
            transform.position += Vector3.left; // Vector3.left(-1, 0, 0), check if the position we are moving to is valid
        else if (Input.GetKeyDown(KeyCode.RightArrow) && OnRange(1))
            transform.position += Vector3.right; // Vector3.right(1, 0, 0)
        // For DownArrow we use GetKey instead of GetKeyDown, so it remains true while the key is pressed.
        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += Vector3.down; // (0, -1, 0)
            previousTime = Time.time; // Time.time: time since the start of the application
            if (!(OnRange(0))) // OnRange is 0, since side is used for horizontal movement not vertical, check if this position is valid, if not, vector up corrects it
            {
                transform.position += Vector3.up;
                gridManager.AddToGrid(); // Add pieces to the grid
                gridManager.CheckForLines(); // Check if a line has been created
                this.enabled = false; // Stop movement and rotation scripts
                pieceRotation.enabled = false;
                FindObjectOfType<SpawnPiece>().NewPiece(); // Referencing this way is necessary since the spawn script is in an existing object not one that is instantiated
            }
        }
    }

    public bool OnRange(int side)
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x) + side; // Since the position can have small variations we round it
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
                return false; // Check if the piece is in our play area
            if (grid[roundedX, roundedY] != null) // Check if it is within the grid
            {
                if (roundedY >= 18) // If it is in the grid and goes beyond our play area above, it's game over
                {
                    FindObjectOfType<SpawnPiece>().EndSpawning();
                }
                return false;
            }
        }
        return true;
    }
}
