using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Score and multiplier
    int score = 0;

    [Space]
    // UI Text
    [SerializeField] Text scoreUI = null;
    [SerializeField] Text deathScreenScore = null;

    // -----------------------------------------------------------------------
    /* START */
    private void Start()
    {
        UpdateUI();
    }

    // -----------------------------------------------------------------------

    /* Add score */
    public void AddScore(int amount)
    {
        score += (int)(amount);
        UpdateUI();
    }

    // -----------------------------------------------------------------------

    /* Update UI */
    void UpdateUI()
    {
        scoreUI.text = score.ToString();
        // Update score on death screen
        deathScreenScore.text = score.ToString();
    }
}
