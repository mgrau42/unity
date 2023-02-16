using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // Referencia al componente de salud del player
    PlayerHealth playerHP = null;

    // Particulas al coger el paquete
    [SerializeField] ParticleSystem particles;

    /* START */
    private void Start()
    {
        // buscar la referencia al componente
        playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    /* ON TRIGGER */
    private void OnTriggerEnter2D(Collider2D other)
    {

        // al tocar al player, recuperar un punto de salud
        if (other.CompareTag("Player") == true)
        {
            // Poner particulas
            particles.transform.parent = null;
            particles.Play();
            Destroy(particles.gameObject, 0.5f);

            playerHP.RestoreHP(1);
            Destroy(this.gameObject);
        }
    }
}
