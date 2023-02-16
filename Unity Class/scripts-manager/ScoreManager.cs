using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	// Puntuación y multiplicador de putos
    int score = 0;
	float multiplier = 1;

    // maximo valor del multiplier
    [SerializeField] float maxMulti = 10;

    [Space]
    // Texto de la interfaz
    [SerializeField] Text scoreUI = null;
    [SerializeField] Text dethScreenScore = null;


    // -----------------------------------------------------------------------
    /* START */
    private void Start()
    {
        UpdateUI();
    }

    // -----------------------------------------------------------------------

    /* Añadir putuacion */
    public void AddScore(int amount)
    {
        score += (int)(amount * multiplier);
        UpdateUI();
    }

    /* Añadir multiplicador de puntos */
    public void AddMultiplayer (float amount)
    {
        if (multiplier < maxMulti)
        {
            // Añadimos al contador y nos aseguramos de que no pasa del maximo
            multiplier += amount;
            if (multiplier > maxMulti)
                multiplier = maxMulti;
        }
        UpdateUI();
    }

    /* Reset del multiplicador */
    public void ResetMulti()
    {
        multiplier = 1;
        UpdateUI();
    }

    // -----------------------------------------------------------------------

    /* Actualizar la interfaz */
    void UpdateUI()
    {
        // Actualizar la puntuacion bajo la barra de vida
        if (multiplier > 1)
            scoreUI.text = score.ToString() + " x" + multiplier;
        else
            scoreUI.text = score.ToString();
        // Actualizar la puntuacion en la pantalla de muerte
        dethScreenScore.text = score.ToString();
    }
}
