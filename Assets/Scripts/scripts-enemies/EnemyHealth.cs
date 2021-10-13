using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int health = 3;
	[SerializeField] ParticleSystem particles = null;   // particulas que se pondran al morir
    [SerializeField] Animator damageAnimator = null;    // animator del spirte de daño

    // manager de la puntuacion
    ScoreManager scoreManager = null;
    [Space]
    // Puntuacion que añade al morir
    [SerializeField] int score = 2;
    [SerializeField] float multi = 0;

    [Space]
    // Referencia al prefab del paquete de salud, para instanciarlo al morir¡
    [SerializeField] GameObject healthPack = null;
    // Posibilidad de soltar un paquete de salud
    [SerializeField] [Range(0, 100)] float packChance = 5;

    // -----------------------------------------------------------------------
    /* START */
    private void Start()
    {
        // en el start, buscar el score manager por el tag, y hacer un get component
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // funcion publica para reducir la salud.
    public void TakeDamage(int damage)
    {
        // reducir la vida
        health -= damage;
        // animacion de daño
        damageAnimator.SetTrigger("damage");
        // si esta a cero, destruye el enemigo
        if (health <= 0)
        {
            // y pon las particulas con la misma jugada que usamos para las balas
            particles.transform.parent = null;
            particles.Play();
            Destroy(particles.gameObject, 0.5f);

            // Añadir puntuacion
            scoreManager.AddScore(score);
            scoreManager.AddMultiplayer(multi);

            // Soltar paquete de salud
            int chance = Random.Range(0, 100);
            if (chance <= packChance)
            {
                GameObject pack = Instantiate(healthPack);
                pack.transform.position = transform.position;
            }

            Destroy(this.gameObject);
        }
    }
}
