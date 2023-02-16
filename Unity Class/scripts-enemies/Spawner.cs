using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Referencias a los prefabs de cada fantasma
    [SerializeField] GameObject ghost = null;
    [SerializeField] GameObject fastGhost = null;
    // Prosibilidades de que aparezca un fantasma rapido.
    [SerializeField] [Range(0, 100)] float fastRandomChance = 20f;

    [Space]
    // Cada cuanto tiempo aparece un nuevo enemigo
    [SerializeField] float spawnCooldown = 2f;
    // Cuanto se reduce ese tiempo cada vez
    [SerializeField] float cooldownReducer = 0.05f;
    // el tiempo minimo al que puede llegar
    [SerializeField] float minCooldown = 0.2f;

    [Space]
    // Distancia del centro a la que aparecen enemigos
    [SerializeField] float spawnDistance = 20;

    float timeCounter = 0;    // contador de tiempo

    // -----------------------------------------------------------------------
    // UPDATE
    private void Update()
    {
        // no seguir spawneando si el player no existe
        if (GameObject.FindWithTag("Player") == null)
            return;

        timeCounter += Time.deltaTime;      // sumar al contador de tiempo

        // si se acaba el tiempo, crear un enemigo y reducir el tiempo
        if (timeCounter >= spawnCooldown)
        {
            CreateEnemy();
            if (spawnCooldown > minCooldown)
                spawnCooldown -= cooldownReducer;

            timeCounter = 0;
        }
    }

    // -----------------------------------------------------------------------
    /* Crear un nuevo enemigo */
    void CreateEnemy ()
    {
        // Obtener un numero aleatorio entre 0 y 100.
        // e instanciar un enemigo u otro en base al resultado
        float chance = Random.Range(0f, 100f);
        GameObject newEnemy = null;
        if (chance > fastRandomChance)
            newEnemy = Instantiate(ghost, this.transform);
        else
            newEnemy = Instantiate(fastGhost, this.transform);

        // colocarlo en un punto aleatorio a la ditancia indicada
        Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        newEnemy.transform.position = transform.position + randomDir.normalized * spawnDistance;
    }
}
