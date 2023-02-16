using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cdInstantiator : MonoBehaviour
{
    float timeCounter = 0;
    [SerializeField] float cdCooldown = 5;
    [SerializeField] Vector2 pointA = Vector2.zero;
    [SerializeField] Vector2 pointB = Vector2.zero;
    [SerializeField] int segmentsToCreate = 8;
    [SerializeField] int startLines = 2;

    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;

    void Start()
    {
        // Add the prefab objects to the list
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        prefabList.Add(Prefab4);

        // Create new and starting lines
        createNewLine();
        createStartLine();
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the time counter
        if (timeCounter < cdCooldown)
            timeCounter += Time.deltaTime;

        // If the cooldown time has been reached
        if (timeCounter >= cdCooldown)
        {
            // Create a new line
            createNewLine();

            // Reset the time counter
            timeCounter = 0;
        }
    }

    void createNewLine()
    {
        // Initialize variables
        float lerpValue = 0f;
        float distance = 1f;
        Vector2 instantiatePosition = Vector2.zero;

        // Calculate the distance value we need for Vector2.Lerp
        distance = (1 /(float)segmentsToCreate);

        // Iterate over the number of segments to create
        for(int i = 0; i < (segmentsToCreate - 1); i++)
        {
            // Increase the lerp value by the distance
            lerpValue += distance;

            // Calculate the position to instantiate the prefab
            instantiatePosition = Vector2.Lerp(pointA, pointB, lerpValue);

            // Instantiate a random prefab from the list
            Instantiate(prefabList[UnityEngine.Random.Range(0,4)], instantiatePosition, transform.rotation);
        }
    }

    void createStartLine()
    {
        // Initialize variables
        float distance = 1f;
        Vector2 pointIniA = pointA;
        Vector2 pointIniB = pointB;
        Vector2 instantiatePosition = Vector2.zero;

        // Iterate over the number of starting lines
        for(int y = 0; y < startLines; y++)
        {
            float lerpValue = 0f;

            // Decrease the y position of the points
            pointIniA.y -= 0.71f;
            pointIniB.y -= 0.71f;

            // Calculate the distance value we need for Vector2.Lerp
            distance = (1 /(float)segmentsToCreate);

            // Iterate over the number of segments to create
            for(int i = 0; i < (segmentsToCreate - 1); i++)
            {
                // Increase the lerp value by the distance
                lerpValue += distance;

                // Calculate the position to instantiate the prefab
                instantiatePosition = Vector2.Lerp(pointIniA, pointIniB, lerpValue);

                // Instantiate a random prefab from the list
                Instantiate(prefabList[UnityEngine.Random.Range(0,4)], instantiatePosition, transform.rotation);
            }
        }
    }
}
