using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Ovde koristimo zaglavlje UnityEngine.UI, da bismo mogli da pristupimo UI kontroli Text.*/

public class ScoreDisplay : MonoBehaviour
{
    Text ScoreText;
    GameSession gameSession;

    /* Kreiramo polja klase ScoreText i gameSession.*/

    void Start()
    {
        ScoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    /* U metodi Start dodeljujemo objekte kreiranim poljima.*/

    void Update()
    {
        ScoreText.text = gameSession.GetScore().ToString();
    }

    /* U metodi Update UI kontroli ScoreText dodeljujemo vrednost, tako što pozivamo metodu iz skripte GameSession.*/
}
