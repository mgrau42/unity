using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ResetScene()
    {
        // Load the scene, there is only one
        // To be able to load scenes, we first have to add them to the building settings
        SceneManager.LoadScene(0);
    }
}
