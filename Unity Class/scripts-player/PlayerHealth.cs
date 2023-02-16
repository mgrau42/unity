using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Para usar el sistema de UI de Unity, tenemos que añadir un nuevo usign
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    // La salud maxima del jugador.
    [SerializeField] int maxHealth = 4;
    // La salud actual
    int currentHealth = 0;

    [Space]
    // Animacion del canvas, para activar animaciones al recibir daño
    [SerializeField] Animator canvasAnimator = null;
    // Referencia a la barra de vida. La viriable Image solo la podemos crear porque hemos añadido el correspodiente using arriba.
    [SerializeField] Image healthBar = null;

    [Space]
    [SerializeField] GameObject deathScreen = null;


    // -----------------------------------------------------------------------
    // START
    private void Start()
    {
        currentHealth = maxHealth;
    }

    // -----------------------------------------------------------------------
    /* Recibir daño */
    public void TakeDamage(int damage)
    {
        // reducir vida
        currentHealth -= damage;

        // Animacion del flash
        canvasAnimator.SetTrigger("flash");

        UpdateUI();

        // si no queda vida, desactivar
        if (currentHealth < 0)
        {
            // activar la pantalla de muerte
            deathScreen.SetActive(true);

            gameObject.SetActive(false);
        }
    }

    /* Recuperar salud */
    public void RestoreHP(int amount)
    {
        // aumentar salud y limitar al maximo
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        UpdateUI();
    }

    // -----------------------------------------------------------------------
    /* Actualizar la barra de vida */
    void UpdateUI()
    {
        // Truquito para hacer facil y rapido las barras de vida ;)
        //      Ojo, la imagen en el canvas tiene que estar en modo Filled
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}
