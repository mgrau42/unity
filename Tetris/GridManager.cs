using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static int width = 10; // width of the grid
    public static int height = 20; // height of the grid
    public pieceMovement pieceMovement; // reference to a script component called pieceMovement
    public static Transform[,] grid = pieceMovement.grid; // a 2D array of Transform objects that represent the grid, taken from pieceMovement
    ScoreManager scoreManager = null; // a reference to a ScoreManager component
    int score = 100; // the score value to add when a line is cleared

    private void Start()
    {
        // In the Start method, find the ScoreManager by tag and get its component. 
        // This is not a prefab and is not connected via an interface. 
        // Instead, we wait until our prefab is instantiated and then reference it.
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    public void AddToGrid()
    {
        // Add all the children of this object to the grid
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX,roundedY] = children;
        }
    }

    public void CheckForLines()
    {
        // Check for lines starting from the bottom of the grid and moving up
        for (int i = height-1; i >= 0; i--)
        {
            // If there is a line, delete it, move everything down, and add score
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
                scoreManager.AddScore(score);
            }
        }
    }

    bool HasLine(int i)
    {
        // Check each column of the given row for nulls (empty spaces)
        for(int j = 0; j < width; j++)
        {
            if(grid[j,i] == null)
                return(false);
        }
        // If no nulls were found, a line exists
        return(true);
    }

    void DeleteLine(int i)
    {
        // Destroy all the objects on the line and set the corresponding positions in the grid to null
        for(int j = 0; j < width; j++)
        {
            Destroy(grid[j,i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        // Move everything above the cleared line down by one
        for (int y = i; y < height; y++)
        {
            for(int j = 0; j < width; j++)
            {
                if(grid[j,y] != null)
                {
                    grid[j, y - 1] = grid[j,y];
                    grid[j,y] = null;
                    grid[j,y -1].transform.position += Vector3.down;
                }
            }
        }
    }
}
