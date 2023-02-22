using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    // Array of pieces to spawn
    public GameObject[] Pieces;

    // Reference to the game object that represents the end screen
    [SerializeField] GameObject EndScreen = null;

    void Start()
    {
        // Start by spawning a new piece
        NewPiece();
    }

    // Spawn a new piece
    public void NewPiece()
    {
        // Instantiate a new piece at the spawn point
        Instantiate(Pieces[Random.Range(0, Pieces.Length)], transform.position, Quaternion.identity);
    }

    // Call this method to stop spawning pieces and show the end screen
    public void EndSpawning()
    {
        // Activate the end screen game object
        EndScreen.SetActive(true);
        // Deactivate this game object (the one that spawns pieces)
        transform.gameObject.SetActive(false);
    }
}
